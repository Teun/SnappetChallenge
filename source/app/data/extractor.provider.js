(function () {

	angular
		.module('data-extractor', [])
		.provider('Data', DataProvider);

	/**
	 * @description
	 * This is the main function to extract data from the JSON file.
	 * The JSON is stored in a CONSTANT that has been loaded with the bootstrapper with a promise to ensure data was laoded.
	 *
	 * Most of the data is processed with LODASH and dates are processed with Moment.js
	 *
	 * This provider can be loaded through Dependency injection with "Data"
	 */
	function DataProvider() {

		return {

			// Create public function for Dependency Injection
			$get: ['RESULTS', 'NOW', function(RESULTS, NOW) {
				var self = this;

				return {

					extract: function(options) {
						options = options || {};
						options.id = parseInt(options.id) || false;
						options.subjectId = parseInt(options.subjectId) || false;
						options.type = options.type || "hierarchically";
						options.from = options.from || 0;
						options.to = options.to || NOW;
						options.showChilds = options.showChilds || true;
						options.showProgress = options.showProgress || false;
						options.showCorrect = options.showCorrect || false;
						options.limit = options.limit || false;
						options.sort = options.sort || false;
						options.minAnswers = options.minAnswers || 0;
						options.reverse = options.reverse || false;

						return self._mapData(RESULTS, options);
					}
				};
			}],

			// This function filters out the most common data first before it passes it on the right 'extractor'
			_mapData: function(data, options) {

				// Extract data from the array with a specified date range
				data = data.filter(function(value) {
					return value.SubmitDateTime >= options.from && value.SubmitDateTime <= options.to;
				});

				// Extract data with a specified id
				if (options.id !== false) {
					data = data.filter(function(value) {
						return (options.id == value.Subject || options.id == value.Domain || options.id == value.LearningObjective || options.id == value.ExerciseId);
					});
				}

				// Extract data with a specified subjectId id
				if (options.subjectId !== false) {
					data = data.filter(function(value) {
						return options.subjectId == value.Subject;
					});
				}

				// Check which mapping we need to use
				if (options.type === "date") {
					return this.mapping.date(data, options);
				} else if (options.type === "correct" || options.type === "incorrect" || options.type === "progress") {
					return this.mapping.sort(data, options);
				} else {
					return this.mapping.hierarchically(data, options);
				}

			},
			mapping: {

				/**
				 * @description
				 * This function merge dates to a specified range and then group them together to sort out the avarage results
				 *
				 * @param {object} data The JSON file in a javascript object
				 * @param {object} options The date-related options that will be applied during merging
				 * * `mergeBy` - merge all dates in the data to a specified method: `day`, `month` or `year`
				 *
				 * @return {object} a nested object, sorted by {SubjectId > Timestamp > Results}
				 */
				date: function(data, options) {
					var self = this;

					// Fallback(s)
					options.mergeBy = options.mergeBy || "day";

					// Sort and merge results by a specific order (per day/month/year)
					// Transform milliseconds to a Date object and reset the time for grouping
					data = data.map(function(value) {
						if (!(value.SubmitDateTime instanceof moment)) {
							value.SubmitDateTime = moment(value.SubmitDateTime);
						}

						if (options.mergeBy == "day" || options.mergeBy == "month" || options.mergeBy == "year") {
							value.SubmitDateTime.hours(0);
						}
						if (options.mergeBy == "month" || options.mergeBy == "year") {
							value.SubmitDateTime.dates(1);
						}
						if (options.mergeBy == "year") {
							value.SubmitDateTime.months(1);
						}

						value.SubmitDateTime.minutes(0).seconds(0).milliseconds(0);
						value.SubmitDateTime = value.SubmitDateTime.valueOf();

						return value;
					});

					// Group all results in an object by "SubjectId > Timestamp"
					data = _.nest(data, ['Subject', 'SubmitDateTime'], function(value) {

						// Loop through the timestamps and collect results made that day/month/year
						_.forEach(value, function(values, timestamp) {
							value[timestamp] = self.sort(values, {
								type: "correct",
								useId: "Subject",
								limit: false,
								minAnswers: 0
							});
						});

						return value;

					});

					return data;
				},

				/**
				 * @description
				 * This function creates an object with the key as the id of the specified `options.useId`
				 * It will also collect all avarage results
				 *
				 * @param {object} data The JSON file in a javascript object
				 * @param {object} options The sort-related options
				 * * `useId` - merge all data to the specified id: `Subject`, `Domain` or `LearningObjective`
				 * * `sortBy` - sort all the data to a specified method: `DESC` or `ASC`
				 * * `type` - the name of the attribute we want to sort: `progress`, `correct` or `incorrect`
				 * * `limit` - limit data results to a specific range
				 *
				 * @return {object} a nested object, sorted by {options.useId > Results}
				 */
				sort: function(data, options) {

					// Fallback(s)
					options.useId = options.useId || "LearningObjective";
					options.sortBy = options.sortBy || "DESC";
					options.type = options.type || "correct";
					options.limit = options.limit || false;

					// Group all data in an object with options.useId as key
					data = _.groupBy(data, options.useId);

					// Loop throught the object and calculate progress and percentages correct and incorrect
					_.forEach(data, function(value, id) {
						var progress = 0,
							difficulty = 0,
							correct = _.where(value, { 'Correct': 1 }),
							incorrect = _.where(value, { 'Correct': 0 });

						// Overwrite previous data
						data[id] = {
							id: id,

							correct: correct.length,
							incorrect: incorrect.length,

							// Collect all progress
							progress: _.reduce(_.groupBy(value, 'Progress'), function(result, array, key) {
								progress = progress + (key * array.length);
								return progress;
							}, {}),

							// Collect all difficulty
							difficulty: _.reduce(_.groupBy(value, 'Difficulty'), function(result, array, key) {
								if(!_.isNaN(parseFloat(key))) {
									difficulty = difficulty + (array.length * parseFloat(key));
								}
								return difficulty;
							}, {}),

							percentages: {
								correct: Math.round((correct.length / (correct.length + incorrect.length)) * 100),
								incorrect: Math.round((incorrect.length / (correct.length + incorrect.length)) * 100)
							},
							data: value
						};

						// Remove results that are not useful yet (i.e. required minAnswers not met  or results zero)
						if ((options.type === "correct" || options.type === "incorrect") && ((correct.length + incorrect.length) <= options.minAnswers || data[id][options.type] === 0)) {
							data = _.omit(data, id);
						}

					});

					// Sort the array ASC or DESC based on sortBy
					data = _.sortByOrder(data, (options.type === "progress" || options.type == "difficulty") ? options.type : 'percentages.' + options.type, (options.sortBy == "ASC"));

					// Check if we need to limit the result
					if (options.limit !== false) {
						data = data.slice(0, options.limit);
					}

					return data;
				},


				/**
				 * @description
				 * This function creates a hierarchically nested object
				 * It will also collect all avarage results if the options allow it
				 *
				 * @param {object} data The JSON file in a javascript object
				 * @param {object} options The sort-related options
				 * * `showCorrect` - include correct and incorrect in the return object
				 * * `showProgress` - include progess in the return object
				 *
				 * @return {object} a nested object, sorted by {Subject > Domain > LearningObjective > ExerciseId)}
				 */
				//
				// It also collects all progress, correct and incorrect answers
				hierarchically: function(data, options) {

					return _.nest(data, ['Subject', 'Domain', 'LearningObjective', 'ExerciseId'], function(value, values) {

						if (options.showCorrect) {
							value.correct = _.where(values, { 'Correct': 1 }).length;
							value.incorrect = _.where(values, { 'Correct': 0 }).length;
						}

						if (options.showProgress) {
							var progress = 0;

							value.progress = _.reduce(_.groupBy(values, 'Progress'), function(result, array, key) {
								progress = progress + (key * array.length);
								return progress;
							}, {});
						}

						return value;

					});
				}

			}
		};

	}

})();

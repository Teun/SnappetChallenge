angular.module('snappet').service('Server', ['DB', function(DB){
	var _this = this;

	_this.data = function(request){
		var result = DB.select(request);
		return result;
	}

	_this.values = function(request){
		var data = DB.select(request);
		var result = _(data.list).map(request.key).uniq().value();
		return result;
	}

	_this.timeline = function(request){
		var data = DB.select(request);

		// Code values for Domain, Subject, Learning Objective
		var domain = 0;
		var subject = 0;
		var objective = 0;

		data.list = _(data.list).chain()
			.map(function(item){
				// Rounding timestamp to day
				item.Date = moment(item.SubmitDateTime.trim())
					.floor(24, 'hours')
					.format('YYYY-MM-DDTHH:mm:ss.SSSS');
				return item;
			})
			// Really tricky part :)
			// Grouping plain array by Domain
			.groupBy('Domain')
			.transform(function(result, item, key){
				domain ++;
				result[key] = _(item).chain()
					// Grouping by Subject inside Domains
					.groupBy('Subject')
					.transform(function(result, item, key){
						subject ++;
						result[key] = _(item).chain()
							// Grouping by Learning Objective inside Subjects
							.groupBy('LearningObjective')
							.transform(function(result, item, key){
								objective ++;
								result[key] = _(item).chain()
									// Grouping by Days inside Learning Objective
									.groupBy('Date')
									.transform(function(result, item, key){
										result[key] = _(item).chain()
											.sortBy('SubmitDateTime')
											// Combining multiple exercises into single item
											.reduce(function(result, item){
												return _.assign(result, item);
											}, {})
											.assign({
												// Assigning a Domain + Subject + Learning Objective type code,
												Type: domain * 100 + subject * 10 + objective + '',
												// Calculating total progress
												Progress: _(item).chain()
													.pluck('Progress')
													.reduce(function(total, current){
														return total + current;
													})
													.value(),
												//Assigning display value 
												Value: 1
											})
											.value();
									}, {})
									// Unfolding Days
									.values()
									.value();
							}, {})
							// Unfolding Learning Objectives
							.values()
							.flatten()
							.value();
					}, {})
					// Unfolding Subjects
					.values()
					.flatten()
					.value();
			}, {})
			// Unfolding domains
			.values()
			.flatten()
			.map(function(item){
				// Filtering off irrelevant values
				return _.omit(item, ['Difficulty', 'ExerciseId', 'Correct', 'SubmittedAnswerId', 'SubmitDateTime']);
			})
			.value();
		

		// Padding missing values. D3 stack requires this.
		var start = _(data.list).chain().pluck('Date').uniq().sortBy().first().value();
		var end   = _(data.list).chain().pluck('Date').uniq().sortBy().last().value();
		var range = [];
		for(var i = start; i <= end; i = moment(i).add(24, 'hours').format('YYYY-MM-DDTHH:mm:ss.SSSS')){
			range.push(i);
		}

		data.list = _(data.list).chain()
			.groupBy('Type')
			.transform(function(result, list, key){
				var type = key;
				result[key] = _.map(range, function(date){
					var item = _.find(list, {Date: date});
					var fake = {
						Date: date,
						Type: type,
						Value: 0
					};
					return item || fake;
				});
			}, {})
			.values()
			.flatten()
			.value();

		data.meta = {
			start:  0,
			length: data.list.length,
			total:  data.list.length
		};

		return data;
	}

	_this.range = function(request){
		var data = DB.select(request);

		var result = _(data.list).chain()
			// Grouping plain array by Domain
			.groupBy('Domain')
			.transform(function(result, item, key){
				result[key] = _(item).chain()
					// Grouping by Subject inside Domains
					.groupBy('Subject')
					.transform(function(result, item, key){
						result[key] = _(item).chain()
							// Grouping by Learning Objective inside Subjects
							.groupBy('LearningObjective')
							.transform(function(result, item, key){
								result[key] = _(item).chain()
									// Grouping by Exersises inside Learning Objective
									.groupBy('ExerciseId')
									.transform(function(result, item, key){
										// Combining multiple attempts into single items
										result[key] = _(item).chain()
											.reduce(function(result, item){
												var result = {
													ExerciseId: item.ExerciseId,
													Difficulty: item.Difficulty
												};
												return result
											}, {})
											.assign({
												Progress: _.first(item).Progress,
												SubmitDateTime: _.last(item).SubmitDateTime,
												Attempts: item
											})
											.value();

									}, {})
									.value();
							}, {})
							.value();
					}, {})
					.value();
			}, {})
			.value();

		return result;
	}

}]);
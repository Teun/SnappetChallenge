(function () {

	angular
		.module('SnappetChallenge')
		.controller('ResultsListCtrl', ResultsList);

	/**
	 * @description
	 * This is the main controller for the result pages.
	 * It extracts the data from the JSON with the `data-extractor` provider, loaded from `data/extractor.provider.js` and assigns the results to the `list.html` view
	 */
	function ResultsList($scope, $rootScope, $routeParams, ChartGauge, ChartSpline, Data, NOW, TRANSLATIONS) {
		var from, to;

		// Remove hidden class
		document.getElementById("wrapper").setAttribute("class", "");

		// Check if user is viewing other dates, if not provide the day from specifications
		if( !_.isUndefined($routeParams.from) && !_.isUndefined($routeParams.to)) {
			from = parseFloat($routeParams.from);
			to = parseFloat($routeParams.to);
		} else {
			from = moment("2015-03-24T00:00:00").valueOf();
			to = NOW;
		}

		// Update the datepicker with the current dates (i.e. for direct linking to a date range)
		$rootScope.updateDatepicker(from, to);

		// Set title
		$scope.fromDate = moment(from).format("DD/MM/YYYY");
		$scope.toDate = moment(to).format("DD/MM/YYYY");
		$scope.todayDate = moment(NOW).format("DD/MM/YYYY");
		$scope.showToDate = ($scope.fromDate == $scope.toDate) ? false : true;

		// Replace string date to 'vandaag'
		$scope.fromDate = $scope.fromDate.replace($scope.todayDate, "vandaag");

		// Extract results from the cached JSON file with the specified date range
		var data = Data.extract({
			type: 'hierarchically',
			showCorrect: true,
			from: from,
			to: to
		});

		// No results?
		if (_.size(data) === 0) {
			$scope.noResults = true;
			return;
		} else {
			$scope.noResults = false;
		}

		// Bind results array to template
		$scope.results = [];

		// Loop through results
		_.forEach(data, function(gauge, id) {
			$scope.results.push({

				// Create a gaugechart with data
				gauge: ChartGauge.create({
					title: TRANSLATIONS[id],
					data: gauge
				}),

				// Get the most correct LearningObjectives
				correct: Data.extract({
					type: 'correct',
					subjectId: id,
					showCorrect: true,
					from: from,
					to: to,
					limit: 10,
					minAnswers: 10
				}),

				// Get the most incorrect LearningObjectives
				incorrect: Data.extract({
					type: 'incorrect',
					subjectId: id,
					showCorrect: true,
					from: from,
					to: to,
					limit: 10,
					minAnswers: 10
				}),

				// Get the total amount of progress made
				progress: Data.extract({
					type: 'progress',
					subjectId: id,
					showCorrect: true,
					from: from,
					to: to,
					limit: 10,
					minAnswers: 10
				})
			});

		});

		// Get data sorted by date
		var dataByDate = Data.extract({
			type: 'date',
			mergeBy: 'day',
			from: from,
			to: to
		});

		// Create a date spline chart based on the most correct answers
		$scope.correctRangeChart = ChartSpline.create({
			yAxisTitle: 'Percentage goed beantwoorden',
			data: dataByDate,
			type: 'correct'
		});

		// Create a date spline chart based on the most progression made
		$scope.progressionRangeChart = ChartSpline.create({
			yAxisTitle: 'Progressie',
			data: dataByDate,
			type: 'progress'
		});

		// Create a date spline chart based on the most difficulty made
		$scope.difficultyRangeChart = ChartSpline.create({
			yAxisTitle: 'Moeilijkheidsgraad',
			data: dataByDate,
			type: 'difficulty'
		});

		// Is it worth showing the charts?
		$scope.showSpline = (_.size(_.sample(dataByDate)) > 1) ? true : false;
	}

})();

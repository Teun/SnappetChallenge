'use strict';

app.controller('reportController',['$scope', '$http', function($scope, $http) {
    $scope.subjects = [];
    $scope.filterRequest = {};
    $scope.today = '2015-03-24 11:30:00Z';
    $scope.filterDateRangeEnum = {
        Weekly: 1,
        Monthly: 2
    };
    $scope.buildReport = function (dateRange) {
        var dateRangeFilter = $scope.today;
        if (dateRange === $scope.filterDateRangeEnum.Weekly) {
            dateRangeFilter = moment.utc($scope.today).subtract(7, 'd').format('YYYY-MM-DD HH:mm:ssZ');
        } else if (dateRange === $scope.filterDateRangeEnum.Monthly) {
            dateRangeFilter = moment.utc($scope.today).subtract(1, 'M').format('YYYY-MM-DD HH:mm:ssZ');
        }
        var parameter = {
            Subject: $scope.filterRequest.subject.name,
            FromDate: dateRangeFilter,
            ToDate: $scope.today
        };
        if ($scope.filterRequest.domain) {
            parameter.Domain = $scope.filterRequest.domain.name;
        }
        if ($scope.filterRequest.learningObjective) {
            parameter.LearningObjective = $scope.filterRequest.learningObjective.name;
        }

        $http.post('api/report/correctanswerreport', parameter).then(function(response) {
            $scope.reportData = response.data;
            var rows = [];
            $scope.reportData.answeredDateResults.forEach(function(element) {
                rows.push({
                    c: [
                        { v: moment(element.answeredDate).format('MMM Do') },
                        { v: element.correctCount, f: element.correctCount.toString() },
                        { v: element.incorrectCount, f: element.incorrectCount.toString() }
                    ]
                });
            });
            buildChart(rows);
        }, function(error) {
            console.log(error.message);
        });
    }

    function buildChart(rows) {
        var chart1 = {};
        chart1.type = 'ColumnChart';
        chart1.cssStyle = 'height:65vh; width:100%;';
        chart1.data = {
            'cols': [
                { id: 'date', label: 'Date', type: 'string' },
                { id: 'correct', label: 'Correct', type: 'number' },
                { id: 'incorrect', label: 'Incorrect', type: 'number' }
            ], 'rows': rows
        };

        chart1.options = {
            'title': 'Сorrelation between correct and incorrect answers during dates',
            'legend': { position: 'top', maxLines: 1 },
            'isStacked': true,
            'fill': $scope.reportData.maxAnsweredCount,
            'displayExactValues': true,
            'vAxis': { 'title': 'Questions count', 'gridlines': { 'count': 6 }, 'textStyle': { 'fontSize': 15 }, 'titleTextStyle': { 'fontSize': 20, 'italic': false } },
            'colors': ['#009b33', '#ff7200'],
            'hAxis': { 'title': 'Date', 'textStyle': { 'fontSize': 15 }, 'titleTextStyle': { 'fontSize': 20, 'italic':false} }
        };

        chart1.formatters = {};
        $scope.chart = chart1;
    }

    function init() {
        $http.get('api/report/subjects').then(function(response) {
            $scope.subjects = response.data.subjects;
        });
    };
    init();
}])
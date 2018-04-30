angular.module("SnappetDashboard")
    .controller("SummaryCtrl",
    ['$scope', '$http', '$location', 'exercisesService',
        function ($scope, $http, $location, exercisesService) {
            $scope.loaded = false;
            $scope.summaryDate = new Date(2015, 2, 2).toLocaleDateString();
            $scope.dataLoading = false;

            function initializeController() {
                $scope.picker = new Pikaday(
                    {
                        field: document.getElementById('SummaryDatePicker'),
                        firstDay: 1,
                        toString(date) {
                            let newDate = Date(date);
                            return new Date(date).toLocaleDateString();
                        },
                        defaultDate: new Date(2015, 2, 2),
                        minDate: new Date(2015, 2, 2),
                        maxDate: new Date(2015, 2, 30),
                        yearRange: [2000, 2020]
                    });
            }

            $scope.getSummaryByDate = function () {
                $scope.loaded = false;
                $scope.dataLoading = true;
                let selectedDate = new Date($scope.summaryDate).toISOString();

                // Get the summary data from the service
                exercisesService.getSummary(selectedDate)
                    .then(function (response) {
                        $scope.data = response;

                        // Initialize the arrays needed for Google Charts
                        $scope.domainPieValues = [];
                        // The first row is the header of the data
                        $scope.domainPieValues.push(['Domain', 'Count']);

                        $scope.subjectsPieValues = [];
                        // The first row is the header of the data
                        $scope.subjectsPieValues.push(['Subject', 'Count']);

                        $scope.learningObjectivesPieValues = [];
                        // The first row is the header of the data
                        $scope.learningObjectivesPieValues.push(['Learning Objectives', 'Count']);

                        $scope.submittedTimesLineChartValues = [];
                        $scope.submittedTimesLineChartValues.push(['Hour', 'Count']);

                        // Fill the arrays with the data from the service
                        if ($scope.data && $scope.data.Domains) {
                            createGoogleChartArray($scope.data.Domains, $scope.domainPieValues);
                        }

                        if ($scope.data && $scope.data.Subjects) {
                            createGoogleChartArray($scope.data.Subjects, $scope.subjectsPieValues);
                        }

                        if ($scope.data && $scope.data.LearningObjectives) {
                            createGoogleChartArray($scope.data.LearningObjectives, $scope.learningObjectivesPieValues);
                        }

                        if ($scope.data && $scope.data.SubmittedDateRanges) {
                            createGoogleChartArray($scope.data.SubmittedDateRanges, $scope.submittedTimesLineChartValues);
                        }
                        //Load Google charts
                        google.charts.load('current', { 'packages': ['corechart'] });
                        // Load the charts after Google Charts loads
                        google.charts.setOnLoadCallback(createAllCharts);
                        $scope.loaded = true;
                        $scope.dataLoading = false;
                    });
            }

            function createAllCharts() {
                if ($scope.domainPieValues && $scope.domainPieValues.length > 1) {
                    LoadGoogleChart($scope.domainPieValues, "domainpiechart", 550, 400, "Domain", true);
                }
                if ($scope.subjectsPieValues && $scope.subjectsPieValues.length > 1) {
                    LoadGoogleChart($scope.subjectsPieValues, "subjectpiechart", 550, 400, "Subject", true);
                }
                if ($scope.learningObjectivesPieValues && $scope.learningObjectivesPieValues.length > 1) {
                    LoadGoogleChart($scope.learningObjectivesPieValues, "learningobjectivesbarchart", 1000, 400, "Learning Objective");
                }
                if ($scope.submittedTimesLineChartValues && $scope.submittedTimesLineChartValues.length > 1) {
                    LoadGoogleChart($scope.submittedTimesLineChartValues, "submittedtimebarchart", 1000, 400, "Submitted Times");
                }
                $scope.loaded = true;
            }

            function resetCharts() {
                $scope.domainPieValues=[];
                $scope.subjectsPieValues = [];
                $scope.learningObjectivesPieValues = [];
                $scope.submittedTimesLineChartValues = [];
            }

            function createGoogleChartArray(data,outputArray) {
                if (data) {
                    for (let x = 0; x < data.length; x++) {
                        if (data[x] && data[x].Key && data[x].Value) {
                            outputArray.push([data[x].Key, data[x].Value]);
                        }
                    }
                }
            }

            function LoadGoogleChart(chartArray, divID, width, height, title, createPieChart) {
                    let data = google.visualization.arrayToDataTable(chartArray);

                    // Set the title, width, and height of the chart
                    let options = { 'title': title, 'width': width, 'height': height };
                    let chart;
                    // Display the chart inside the element with id of divID
                    if (createPieChart) {
                        chart = new google.visualization.PieChart(document.getElementById(divID));
                    } else {
                        chart = new google.visualization.ColumnChart(document.getElementById(divID));
                    }
                    chart.draw(data, options);
            }

            initializeController();
        }]);
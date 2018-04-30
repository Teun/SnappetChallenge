angular.module("SnappetDashboard")
    .controller("DashboardCtrl",
    ['$scope', '$http', '$location', 'exercisesService',
        function ($scope, $http, $location, exercisesService) {
            $scope.loaded = false;
            $scope.dataLoaded = true;

            function initializeController() {
                $scope.pageNumber = 1;
                $scope.exercisesPerPage = 25;
                $scope.exercisesPerPageOptions = [5, 10, 15, 20, 25];

                exercisesService.getDropdownValues().then(function (response) {
                    if (response) {
                        $scope.domains = response.Domains;
                        $scope.exerciseIDs = response.ExerciseIds;
                        $scope.learningObjectives = response.LearningObjectives;
                        $scope.exerciseSubjects = response.Subjects;
                        $scope.exerciseUsers = response.Users;
                    }
                    $scope.loaded = true;
                });
            }

            initializeController();

            $scope.nextPage = function () {
                $scope.pageNumber++;
                $scope.getFilteredExercises();
            } 

            $scope.previousPage = function () {
                if ($scope.pageNumber > 1) {
                    $scope.pageNumber--;
                    $scope.getFilteredExercises();
                }
            } 

            $scope.getFilteredExercises = function () {
                $scope.dataLoaded = false;
                exercisesService.getFilteredExercises($scope.pageNumber, $scope.exercisesPerPage, $scope.selectedDomain,
                    $scope.selectedExerciseID, $scope.selectedLearningObjective, $scope.selectedSubject, $scope.selectedUser)
                    .then(function (response) {
                        $scope.exercises = response;
                        $scope.dataLoaded = true;
                    });
            }

            $scope.parseJSONDate = function (jsonDateString) {
                return new Date(parseInt(jsonDateString.replace('/Date(', '')));
            }

            exercisesService.getExercises(1, 200).then(function (response) {
                $scope.data = response;
            });

            $scope.domainSelected = function () {
                if ($scope.selectedDomain && $scope.pageNumber && $scope.exercisesPerPage) {
                    exercisesService.getExercisesByDomain($scope.pageNumber, $scope.exercisesPerPage, $scope.selectedDomain)
                        .then(function (response) {
                            $scope.exercises = response;
                        });
                }
            }

            $scope.exercisesPerPageChanged = function () {
                $scope.pageNumber = 1;
                if ($scope.exercises && $scope.exercises.length > 0) {
                    $scope.getFilteredExercises();
                }
            }
        }]);
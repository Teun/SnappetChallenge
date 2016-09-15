angular.module('snptApp')
    .controller('huidigCtrl', [
        '$scope',
        'classService',
        'learningObjectiveService',

        function ($scope, classService, learningObjectiveService) {
            var staticClassId = 37;

            var init = function () {
                classService.getCurrentActivity(staticClassId, function (data) {
                    $scope.currentActivity = data;
                });
            };

            $scope.selectActiveStudent = function (activeStudent) {
                $scope.activeStudent = activeStudent;

                learningObjectiveService.GetProgress(staticClassId, activeStudent.userID, function (data) {
                    $scope.progress = data;
                });
            };

            $scope.setProgressOrder = function (orderProperty) {
                $scope.orderProperty = orderProperty;
            };

            init();
        }
    ]
);
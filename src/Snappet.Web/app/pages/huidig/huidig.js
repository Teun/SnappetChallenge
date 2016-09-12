angular.module('snptApp')
    .controller('huidigCtrl', [
        '$scope',
        'classService',

        function ($scope, classService) {
            var init = function() {
                classService.getClasses(function (data) {
                    $scope.classes = data;
                });
            }

            init();
        }
    ]
);
angular.module('snptApp')
    .controller('zoekenCtrl', function ($scope) {
        $scope.searchVisible = false;
        $scope.itemsPerPage = 20;
        $scope.items = [];

        function init() {
            

            for (var i = 0; i < 500; i++) {
                $scope.items.push({
                    ID: i
                });
            }
        }

        $scope.toggleSearchVisibility = function () {
            $scope.searchVisible = !$scope.searchVisible;
        }

        $scope.getTimes = function (n) {
            return new Array(n);
        };

        init();
    }
);

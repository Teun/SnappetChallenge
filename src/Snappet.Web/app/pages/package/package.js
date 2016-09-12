angular.module('cvdApp')
    .controller('packageCtrl', function ($scope, $stateParams) {
        function init() {
            $scope.id = $stateParams.id;
            $scope.wijzigingsHistorie = [];
            
            for (var i = 0; i < 10; i++) {
                $scope.wijzigingsHistorie.push({
                    ID: i
                });
            }
        };

        init();
    }
);
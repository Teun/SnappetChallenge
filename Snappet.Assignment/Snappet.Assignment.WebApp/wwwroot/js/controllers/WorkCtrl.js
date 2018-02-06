app.controller("WorkCtrl", ["$scope", "httpService", function ($scope, httpService ) {
    

    
    $scope.getAllWorks = function () {



        httpService.get("/api/work/getAll").then(
            function (result) {
                $scope.works = result.data;
                $scope.sort.sortingOrder = 'submitDateTime';
                $scope.groupToPages($scope.works);
               
            },
            function (error) {
                //log error
            })
       
    }


    $scope.getTodayWorks = function () {



        httpService.get("/api/work/GetToday").then(
            function (result) {
                $scope.works = result.data;
                $scope.sort.sortingOrder = 'submitDateTime';
                $scope.groupToPages($scope.works);

            },
            function (error) {
                //log error
            })

    }
    
  
}]);

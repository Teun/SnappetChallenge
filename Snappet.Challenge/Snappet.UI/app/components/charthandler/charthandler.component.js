(function() {
  "use strict";

  function ChartHandler($scope,DataService, $q) {
    var vm = this;
    vm.selectedchart = "bar";
    vm.iserror = false;
   
    vm.changecharttype = function(type) {
      vm.selectedchart = type;
    };

    $scope.$on('generatechart',function(event,args){
      var utcdate =
      args.selecteddate.getUTCFullYear() +
      "-" +
      ("0" + (args.selecteddate.getUTCMonth() + 1)).slice(-2) +
      "-" +
      ("0" + (args.selecteddate.getUTCDate() + 1)).slice(-2);
      vm.loadData(utcdate,args.subject);
    });

    vm.loadData = function(selecteddate, subject) {
      DataService.getChartData(selecteddate, subject).then(
        function(response) {
          vm.datafeed = response;
          vm.iserror = false;
        },
        function() {
          vm.iserror = true;
        }
      );
    }
    vm.loadData("2015-03-02", "All");
  }

  angular.module("snappet").controller("ChartHandlerController", ChartHandler);

  ChartHandler.$inject = ["$scope","DataService", "$q"];
})();

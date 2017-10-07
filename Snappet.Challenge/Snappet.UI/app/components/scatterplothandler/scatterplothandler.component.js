(function() {
    "use strict";
  
    function ScatterPlotChartHandler($scope,DataService, $q) {
      var vm = this;
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
        DataService.getScatterPlotData(selecteddate, subject).then(
          function(response) {
            mungeDataToScatterChartCompatibleData(response);
            vm.iserror = false;
            console.log(response);
          },
          function() {
            vm.iserror = true;
          }
        );
      }

      function mungeDataToScatterChartCompatibleData(sourcedata){
            var data=[];
            for(var i=0; i<sourcedata.length-1; i++){
                data.push([sourcedata[i].Key, sourcedata[i].Value])
            }
            vm.datafeed=data;
      }
      vm.loadData("2015-03-02", "All");
    }
  
    angular.module("snappet").controller("ScatterPlotChartController", ScatterPlotChartHandler);
  
    ScatterPlotChartHandler.$inject = ["$scope","DataService", "$q"];
  })();
  
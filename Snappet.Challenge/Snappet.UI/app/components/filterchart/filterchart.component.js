(function(){
    "use strict"

    function FilterChart($rootScope){
        return{
            element:"EA",
            scope:{

            },
            templateUrl:"components/filterchart/filterchart.component.html",
            controller:function(){
                var vm=this;
                vm.selecteddate = new Date("2015", "02", "02");
                vm.selectedchart = "bar";
                vm.subject = "All";
                vm.showDatePicker = function() {
                  vm.showdatepicker = true;
                };
                vm.generateChart = function() {
                    $rootScope.$broadcast("generatechart",{selecteddate:vm.selecteddate,subject:vm.subject});
                }
            },
            controllerAs:"FilterChart",
            bindToController: true,
            link:function(scope,element,attributes){

            },
            
        }
    }

    angular.module("snappet")
            .directive("filterChart",FilterChart);

    angular.$inject=["$rootScope"];


})();

(function(){

    'use strict'

    function DashBoardController(){
        var vm=this;
        vm.message="Hello";
    }
    angular.module('snappet')
            .controller("DashboardController",DashBoardController);
    
    angular.injector=[];

})();
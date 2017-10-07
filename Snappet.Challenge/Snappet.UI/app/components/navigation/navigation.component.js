(function(){
    'use strict'

    function Navigation(){
        return {
            restrict:'EA',
            templateUrl:'components/navigation/navigation.component.html',
            controller:function(){

            },
            link:function(scope, element, attributes){

            }
        }
    }

    angular.module('snappet')
            .directive('navigation',Navigation);

})();
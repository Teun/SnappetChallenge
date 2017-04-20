angular.module('snappet').directive('sorting',function(){
    return {
        restrict:'E',
        template:'<span><span class="glyphicon glyphicon-chevron-up" aria-hidden="true" ng-show="reverseStatus"></span><span class="glyphicon glyphicon-chevron-down" ng-hide="reverseStatus" aria-hidden="true"></span></span>',
        scope:{
            reverseStatus:'=',
        }

    }
})
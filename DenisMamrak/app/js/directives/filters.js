angular.module('snappet').directive('filters', function(){
	return {
		restrict: 'E',
		replace: true,
		scope: {
			template: '@',
			filters: '=',
			data: '=',
			callback: '&'
		},
		templateUrl: function($element, $attrs) {
			return $attrs.template;
		},
		link: function($scope, $element, $attrs){

			$scope.filter = function(){
				$scope.callback({
					filters: $scope.filters
				});
			}

			$scope.reset = function(){
				$scope.filters = {};
				$scope.filter();
			}

		}
	};
});
angular.module('snappet').directive('datePicker', ['$timeout', '$window', function($timeout, $window){
	return {
		restrict: 'A',
		scope: false,
		link: function($scope, $element, $attrs){

			var picker = new Pikaday({
				field:  $element[0],
				firstDay: 1,
				format: 'YYYY-MM-DDTHH:mm:ss.SSSS',
				onSelect: function() {
					$scope.$digest()
				}
			});

			$scope.$on('$routeChangeStart', function(){
				picker.destroy();
			});

		}
	};
}]);
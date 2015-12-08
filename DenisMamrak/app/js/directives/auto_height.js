angular.module('snappet').directive('autoHeight', ['$timeout', '$window', function($timeout, $window){
	return {
		restrict: 'A',
		scope: false,
		link: function($scope, $element, $attrs){

			$timeout(function(){
				setHeight();
			}, 0);
				
			function setHeight(){
				var height = $window.innerHeight;
				var offset = $element.offset();
				var shift  = Number($attrs.autoHeight);

				var result = (height - offset.top + shift) + 'px';

				$element.css({
					height: result
				});
			}

		}
	};
}]);
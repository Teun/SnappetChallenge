angular.module('snappet').controller('MainCtrl', ['$scope', '$routeParams', '$location', function($scope, $routeParams, $location){
	var _this = this;

	$scope.$on('$routeChangeSuccess', function(){
		var reg = /\/(.*?)(\/|$)/;
		var page = $location.path();
		_this.page = reg.exec(page)[1];
		_this.UserId = $routeParams.UserId;
	});

}]);
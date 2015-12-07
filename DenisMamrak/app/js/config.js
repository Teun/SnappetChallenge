angular.module('snappet').config(['$routeProvider', function($routeProvider){
	$routeProvider
		.when('/grid', {
			templateUrl: 'tpl/grid.html',
			controller: 'GridCtrl as grid',
			reloadOnSearch: false
		})
		.when('/profile/:UserId', {
			templateUrl: 'tpl/profile.html',
			controller: 'ProfileCtrl as profile',
			reloadOnSearch: false
		})
		.otherwise({
			redirectTo: '/grid'
		});
}]);
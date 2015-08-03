(function() {

	angular
		.module('SnappetChallenge')
		.config(Routing);
	/**
	 * @description
	 * Pretty straight forward, or backwards, depending on your navigation.
	 */
	function Routing($routeProvider) {

		$routeProvider
			.when('/resultaten', {
				templateUrl: 'results/list.html',
				controller: 'ResultsListCtrl'
			})
			.when('/resultaten/:from/:to', {
				templateUrl: 'results/list.html',
				controller: 'ResultsListCtrl'
			})
			.otherwise({
				redirectTo: '/resultaten'
			});

	}

})();

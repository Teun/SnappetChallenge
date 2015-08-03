(function(document, window) {

	/**
	 * @description
	 * This function will load the JSON with a promise and will store the results into a constant value
	 */

	// Store base href
	var href = window.location.href.split("#/");

	deferredBootstrapper.bootstrap({
		element: document.body,
		module: 'SnappetChallenge',
		injectorModules: 'angular-loading-bar',
		resolve: {
			RESULTS: ['$http', function($http) {
				return $http.get(href[0] + "json/data.json"); // Get the JSON and return it with a promise
			}],
			TRANSLATIONS: ['$http', function($http) {
				return $http.get(href[0] + "json/translations.json"); // Get the JSON and return it with a promise
			}]
		},
		onError: function(error) {
			alert('Could not bootstrap, error: ' + error);
		}
	});

})(document, window);

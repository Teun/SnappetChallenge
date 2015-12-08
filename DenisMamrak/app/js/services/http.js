angular.module('snappet').service('http', ['$timeout', '$q', 'Server', function($timeout, $q, Server){
	var _this = this;

	_this.get = function(api, request){
		// Redirecting get request to certain "API" mock
		var result = Server[api](request);
		var deferred = $q.defer();
		var promise = deferred.promise;

		// Returning the result asynchronously after random delay
		// to mock the real server behavior
		var delay = Math.round(Math.random() * 750 + 250);
		$timeout(function(){
			deferred.resolve(result);
		}, delay);

		return promise;
	}

}]);
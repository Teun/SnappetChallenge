angular.module('snappet').controller('ProfileCtrl', ['$scope', '$q', '$routeParams', '$location', 'http', function($scope, $q, $routeParams, $location, http){
	var _this = this;

	_this.UserId = $routeParams.UserId;
	_this.filters = $location.search();

	_this.loading = false;

	$scope.$on('$routeUpdate', function(){
		// Tricky check to prevent double request
		// if a filter value changed to empty from the URL string
		var newVal = cleanup($location.search());
		var oldVal = cleanup(_this.filters);
		var equals = angular.equals(newVal, oldVal);
		if(!equals){
			_this.filters = newVal;
			_this.filter(_this.filters);
		}
	});

	start();

	_this.filter = function(filters){
		_this.filters = cleanup(filters);

		$location.search(_this.filters);
		getTimeline();
	}

	_this.drill = function(data){
		var start = data.Date;
		var end = moment(start).add(24, 'hours').format('YYYY-MM-DDTHH:mm:ss.SSSS');
		
		getRange(start, end);
		$scope.$digest();
	}

	function start(){
		_this.loading = true;
		_this.categories = {};

		$q.all([
			http.get('values', {key: 'Domain', filters: {'UserId': _this.UserId}})
				.then(function(response){
					_this.categories['Domain'] = response;
				}),
			http.get('values', {key: 'Subject', filters: {'UserId': _this.UserId}})
				.then(function(response){
					_this.categories['Subject'] = response;
				}),
			http.get('values', {key: 'LearningObjective', filters: {'UserId': _this.UserId}})
				.then(function(response){
					_this.categories['LearningObjective'] = response;
				})
		])
		.then(function(){
			getTimeline();
		});
	}

	function getTimeline(){
		_this.loading = true;

		var api = 'timeline';
		var request = {
			sort:   {
				key: 'SubmitDateTime',
				asc: true
			},
			filters: angular.extend({}, _this.filters, {UserId: _this.UserId})
		};
		http.get(api, request)
			.then(function(response){
				_this.data = response;
				_this.timeline = {};

				_this.loading = false;
			});
	}

	function getRange(start, end){
		_this.loading = true;

		var api = 'range';
		var request = {
			sort:   {
				key: 'SubmitDateTime',
				asc: true
			},
			filters: angular.extend({}, _this.filters,
				{
					UserId: _this.UserId
				},
				{
					SubmitDateTime__gte: start,
					SubmitDateTime__lte: end
				})
		};
		http.get(api, request)
			.then(function(response){
				_this.timeline = response;

				_this.loading = false;
			});
	}

	// TBD: Move this to the service
	function cleanup(data){
		var result = {};
		angular.forEach(data, function(value, key){
			if(value != ''){
				result[key] = value;
			}
		});
		return result;
	}

}]);
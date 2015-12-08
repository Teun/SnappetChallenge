angular.module('snappet').controller('GridCtrl', ['$q', '$scope', '$location', 'http', function($q, $scope, $location, http){
	var _this = this;

	_this.page = {
		number: 0,
		size: 50
	};

	_this.sort = {
		key: 'SubmitDateTime',
		asc: true
	};

	_this.filters = $location.search();

	_this.loading = false;

	var reset = true;

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

	_this.load = function(){
		_this.page.number ++;
		getData();
	};

	_this.order = function(key){
		if(_this.sort.key != key){
			_this.sort.asc = true;
		}else{
			_this.sort.asc = !_this.sort.asc;
		}
		_this.sort.key = key;
		
		_this.page.number = 0;
		reset = true;

		getData(true);
	};

	_this.filter = function(filters){
		_this.filters = cleanup(filters);

		$location.search(_this.filters);
		
		_this.page.number = 0;
		reset = true;

		getData();
	}

	_this.toggle = function(key, value){
		if(value != null && value !== ''){
			_this.filters[key] = value;
		}else{
			delete _this.filters[key];
		}

		$location.search(_this.filters);
		
		_this.page.number = 0;
		reset = true;

		getData();
	};

	_this.reset = function(){
		_this.filters = {};

		$location.search(_this.filters);
		
		_this.page.number = 0;
		reset = true;

		getData();
	};

	function start(){
		_this.loading = true;
		_this.categories = {};

		$q.all([
			http.get('values', {key: 'Domain'})
				.then(function(response){
					_this.categories['Domain'] = response;
				}),
			http.get('values', {key: 'Subject'})
				.then(function(response){
					_this.categories['Subject'] = response;
				}),
			http.get('values', {key: 'LearningObjective'})
				.then(function(response){
					_this.categories['LearningObjective'] = response;
				})
		])
		.then(function(){
			getData();
		});
	}

	function getData(){
		_this.loading = true;

		var api = 'data';
		var request = {
			start:   _this.page.size * _this.page.number,
			offset:  _this.page.size,
			sort:    _this.sort,
			filters: _this.filters
		};
		http.get(api, request)
			.then(function(response){
				if(reset){
					_this.data = {
						meta: {},
						list: []
					};

					reset = false;
				}

				_this.data.meta = response.meta;
				_this.data.list = _this.data.list.concat(response.list);

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
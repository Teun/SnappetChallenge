angular
	.module('snappetApp.student', [
		'ui.router'
	])
	.config(function ($stateProvider, $urlRouterProvider) {
		$urlRouterProvider.otherwise('/');

		$stateProvider
			.state('student', {
				abstract: true,
				url: '/student',
				template: '<ui-view/>'
			})
			.state('student.list', {
				url: '?:date',
				templateUrl: '/Content/js/views/student/list.html',
				controller: 'StudentListController'
			})
			.state('student.detail', {
				url: '/{userId}/{date}',
				templateUrl: '/Content/js/views/student/detail.html',
				controller: 'StudentDetailController'
			});
	})
	.controller('StudentListController', function ($scope, $http, $stateParams) {

		$scope.selectedDate = null;
		$scope.studentOverviews = null;

		$scope.loading = true;

		$http({ url: 'api/result/overview' }).then(function (response) {
			$scope.dates = response.data.dates;
			$scope.loading = false;
		});

		$scope.overviewLoading = true;

		$scope.selectedDateChange = function () {
			$scope.loadByDate($scope.selectedDate);
		}

		$scope.loadByDate = function (date) {
			$scope.overviewLoading = true;
			$http({ url: 'api/result/day-overview', params: { date: date } }).then(function (response) {
				$scope.studentOverviews = response.data;
				$scope.overviewLoading = false;
			});
		}

		if ($stateParams.date != null) {
			$scope.selectedDate = $stateParams.date;
			$scope.selectedDateChange();
		}

	})
	.controller('StudentDetailController', function ($scope, $http, $stateParams) {

		$scope.studentOverview = null;

		$scope.loading = true;

		$http({ url: 'api/result/day-detail', params: { date: $stateParams.date, userId: $stateParams.userId } }).then(function (response) {
			$scope.studentOverview = response.data;
			$scope.loading = false;
		});

	});

angular
	.module('snappetApp', [
		'ngSanitize',
		'ui.router',
		'ui.select',
		'ui.bootstrap.datetimepicker',
		'snappetApp.student'
	])
	.config(function ($stateProvider, $urlRouterProvider, uiSelectConfig) {

		uiSelectConfig.theme = 'bootstrap';

		$urlRouterProvider.otherwise('/');

		$stateProvider
			.state('home', {
				url: '/',
				templateUrl: '/Content/js/views/dashboard.html'
			});

	});
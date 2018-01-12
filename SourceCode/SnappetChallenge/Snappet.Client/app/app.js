(function () {
    "use strict";

    var app = angular.module("SnappetApp", ['ui.router','common']);
    app.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

        $urlRouterProvider.otherwise('/');

        $stateProvider
			.state('home', {
			    url: '/',
			    templateUrl: '/app/reports/dashboardView.html',
			    controller: 'reportCtrl as vm'
			});
            
        //use the HTML5 History API dashboardView
        //$locationProvider.html5Mode(true);
    }]);

}());
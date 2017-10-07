'use strict';

// Declare app level module which depends on views, and components
angular.module('snappet', [
  'ngRoute',
  'ui.bootstrap',
  'ngAnimate'
]).
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  $locationProvider.hashPrefix('!');
  
  $routeProvider.otherwise({redirectTo: '/charthandler'});

  $routeProvider.when('/dashboard', {
    templateUrl: 'components/dashboard/dashboard.component.html',
    controller: 'DashboardController',
    controllerAs:'Dashboard'
  }).when('/charthandler',{
    templateUrl: 'components/charthandler/charthandler.component.html',
    controller: 'ChartHandlerController',
    controllerAs:'ChartHandler'
  }).when('/scatterplot',{
    templateUrl: 'components/scatterplothandler/scatterplothandler.component.html',
    controller: 'ScatterPlotChartController',
    controllerAs:'ScatterPlotHandler'
  });
}]);

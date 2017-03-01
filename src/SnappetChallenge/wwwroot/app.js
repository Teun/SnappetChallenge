var app = angular.module('studyApp', ['ngRoute', 'googlechart'])
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'views/main.html',
                    controller: 'reportController'
                });
        }
    ])
    .value('googleChartApiConfig', {
        version: '1.1',
        optionalSettings: {
            packages: ['bar'],
            language: 'en'
        }
    });
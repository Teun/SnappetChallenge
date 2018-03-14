
(function () {

    angular.module('students-report', ['ngRoute'])
    .config(configure);

    function configure($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(false).hashPrefix("");

        $routeProvider.when('/list', {

            templateUrl: '/views/display.html',
            controller: 'studentReportCtrl'            

        }).otherwise({
            redirectTo: '/list'
        });

    }


})();
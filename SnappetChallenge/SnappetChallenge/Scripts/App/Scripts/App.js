angular.module("SnappetDashboard", ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
        $routeProvider
            .when('/dashboard', { templateUrl: '../Scripts/App/Views/Dashboard.html', controller: 'DashboardCtrl' })
            .when('/summary', { templateUrl: '../Scripts/App/Views/Summary.html', controller: 'SummaryCtrl' })
            .otherwise({ redirectTo: '/summary' });
        
        // Internet Explorer caches all ajax get requests by default.
        //  The following code will prevent this.
        //  Initialize get if not there
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }

        // Disable IE ajax request caching
        $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
    }])
angular.module('snptApp', [
    'ui.router',
    'ngAnimate',
    'ngResource',
    'ngSanitize',
    'ui.bootstrap',
    'mgcrea.ngStrap'
])

.config(function ($stateProvider, $urlRouterProvider, $datepickerProvider, $selectProvider, $dropdownProvider) {
    $urlRouterProvider.otherwise("/huidige");

    $stateProvider
        .state('huidig', {
            url: "/huidig",
            templateUrl: "app/pages/huidig/huidig.html",
            controller: "huidigCtrl"
        })

        .state('zoeken', {
            url: "/zoeken",
            templateUrl: "app/pages/zoeken/zoeken.html",
            controller: "zoekenCtrl"
        })

        .state('populair', {
            url: "/populair",
            templateUrl: "app/pages/populair/populair.html",
            controller: "populairCtrl"
        })

        .state('leerlingen', {
            url: "/leerlingen",
            templateUrl: "app/pages/leerlingen/leerlingen.html",
            controller: "leerlingenCtrl"
        })

        .state('help', {
            url: "/help",
            templateUrl: "app/pages/help/help.html",
            controller: "helpCtrl"
        })

        .state('login', {
            url: "/login",
            templateUrl: "app/pages/login/login.html",
            controller: "loginCtrl"
        })

        .state('package', {
            url: "/package/:id",
            templateUrl: "app/pages/package/package.html",
            controller: 'packageCtrl'
        })
            .state('package.algemeen', {
                url: "/algemeen",
                templateUrl: "app/pages/package/package.algemeen.html",
            })
            .state('package.kaarten', {
                url: "/kaarten",
                templateUrl: "app/pages/package/package.kaarten.html",
            })
            .state('package.rapporten', {
                url: "/rapporten",
                templateUrl: "app/pages/package/package.rapporten.html",
            });

    angular.extend($datepickerProvider.defaults, {
        dateFormat: 'dd-MM-yyyy',
        startWeek: 1,
        container: 'body',
        //trigger: 'click'
    });

    angular.extend($selectProvider.defaults, {
        animation: 'am-flip-x',
        sort: false,
        trigger: 'click'
    });

    angular.extend($dropdownProvider.defaults, {
        animation: 'am-flip-x',
        trigger: 'click',
        placement: 'bottom-right'
    });
})

.controller('ApplicationCtrl', function ($scope, $state) {
    $scope.$state = $state;
})
;
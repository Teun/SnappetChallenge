app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.caseInsensitiveMatch = true;
    $routeProvider
        .when("/", {
            templateUrl: "html/work/all-works-tmp.html", 
            controller: "WorkCtrl"
        })
        .when("/home", {
            templateUrl: "html/work/all-works-tmp.html", 
            controller: "WorkCtrl"
        })       
       
       
        .when("/today-works", {
            templateUrl: "html/work/today-works-tmp.html",
            controller: "WorkCtrl"
        })
        .otherwise({ redirectTo: '/home' });
  
    $locationProvider.html5Mode(true);
})
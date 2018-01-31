var SnappetChallenge;
(function (SnappetChallenge) {
    var RootApp = /** @class */ (function () {
        function RootApp() {
            var _this = this;
            this.catalogName = ko.observable();
            this.services = new SnappetChallenge.Services();
            this.mainViewModel = new MainViewModel();
            this.formManager = new SnappetChallenge.FormManager(this.mainViewModel);
            this.start = function () {
                var routerConfig = Sammy("#site-content");
                //this.setupRoute(routerConfig, "#/learningObjectives");
                ko.applyBindings(_this.mainViewModel);
                $("#site-content").fadeIn(500);
            };
            this.setupRoute = function (router, routePattern, catalog) {
            };
        }
        return RootApp;
    }());
    SnappetChallenge.RootApp = RootApp;
    var MainViewModel = /** @class */ (function () {
        function MainViewModel() {
            this.form = ko.observable();
            this.catalogName = ko.observable();
        }
        return MainViewModel;
    }());
    SnappetChallenge.MainViewModel = MainViewModel;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=rootApp.js.map
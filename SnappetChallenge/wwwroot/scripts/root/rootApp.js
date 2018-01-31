var SnappetChallenge;
(function (SnappetChallenge) {
    var Root;
    (function (Root) {
        var RootApp = /** @class */ (function () {
            function RootApp(subApp) {
                var _this = this;
                this.catalogName = ko.observable();
                this.services = new Services();
                this.mainViewModel = new MainViewModel();
                this.formManager = new Root.FormManager(this.mainViewModel);
                this.start = function () {
                    var response = subApp.init(_this);
                    _this.mainViewModel.catalogName(response.catalogName);
                    ko.applyBindings(_this.mainViewModel);
                    $("#site-content").fadeIn(500);
                };
            }
            return RootApp;
        }());
        Root.RootApp = RootApp;
        var MainViewModel = /** @class */ (function () {
            function MainViewModel() {
                this.form = ko.observable();
                this.catalogName = ko.observable();
            }
            return MainViewModel;
        }());
        Root.MainViewModel = MainViewModel;
        var Services = /** @class */ (function () {
            function Services() {
                this.dialogManager = new SnappetChallenge.DialogManager();
                this.httpClient = new SnappetChallenge.JQueryHttpClient(this.dialogManager);
                this.apiUriConfig = new SnappetChallenge.ApiUriConfig();
                this.apiClient = new SnappetChallenge.ApiClient(this.httpClient, this.apiUriConfig);
            }
            return Services;
        }());
        Root.Services = Services;
    })(Root = SnappetChallenge.Root || (SnappetChallenge.Root = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=rootApp.js.map
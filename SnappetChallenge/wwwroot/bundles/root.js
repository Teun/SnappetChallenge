var SnappetChallenge;
(function (SnappetChallenge) {
    var FormManager = /** @class */ (function () {
        function FormManager(mainFormHost) {
            this.showMainForm = function (form) {
                mainFormHost.form(form);
            };
        }
        return FormManager;
    }());
    SnappetChallenge.FormManager = FormManager;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=formManager.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var RootApp = /** @class */ (function () {
        function RootApp() {
            var _this = this;
            this.services = new SnappetChallenge.Services();
            this.mainViewModel = new MainViewModel();
            this.formManager = new SnappetChallenge.FormManager(this.mainViewModel);
            this.start = function () {
                var routerConfig = Sammy("#site-content");
                SnappetChallenge.KoExtensions.init();
                SnappetChallenge.catalogRegistry.getCatalogs()
                    .forEach(function (c) {
                    var catalogInfo = c.init(_this.services, routerConfig);
                    catalogInfo.routes.forEach(function (r) {
                        _this.setupRoute(routerConfig, r.pattern, r.form, catalogInfo.catalogName);
                    });
                    _this.mainViewModel.registredCatalogs.push(catalogInfo);
                });
                ko.applyBindings(_this.mainViewModel);
                if (_this.mainViewModel.registredCatalogs().length)
                    routerConfig.run(_this.mainViewModel.registredCatalogs()[0].defaultRoute);
                $("#site-content").fadeIn(500);
            };
            this.setupRoute = function (router, routePattern, form, catalogName) {
                router.get(routePattern, function (context) {
                    form.data.init(context.params);
                    _this.mainViewModel.form(form);
                    _this.mainViewModel.activeCatalogName(catalogName);
                });
            };
        }
        return RootApp;
    }());
    SnappetChallenge.RootApp = RootApp;
    var MainViewModel = /** @class */ (function () {
        function MainViewModel() {
            var _this = this;
            this.form = ko.observable();
            this.registredCatalogs = ko.observableArray([]);
            this.activeCatalogName = ko.observable();
            this.activeCatalog = ko.computed(function () {
                return _this.registredCatalogs()
                    .filter(function (c) { return c.catalogName === _this.activeCatalogName(); })[0];
            });
        }
        return MainViewModel;
    }());
    SnappetChallenge.MainViewModel = MainViewModel;
})(SnappetChallenge || (SnappetChallenge = {}));
$(function () {
    new SnappetChallenge.RootApp().start();
});
//# sourceMappingURL=rootApp.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var Route = /** @class */ (function () {
        function Route(pattern, form) {
            this.pattern = pattern;
            this.form = form;
        }
        return Route;
    }());
    SnappetChallenge.Route = Route;
    var TemplateForm = /** @class */ (function () {
        function TemplateForm(name, data) {
            this.name = name;
            this.data = data;
        }
        return TemplateForm;
    }());
    SnappetChallenge.TemplateForm = TemplateForm;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=templateForm.js.map
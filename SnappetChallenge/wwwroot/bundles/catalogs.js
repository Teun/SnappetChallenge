//# sourceMappingURL=catalog.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var CatalogInitResponse = /** @class */ (function () {
        function CatalogInitResponse(catalogName, defaultRoute, title, routes) {
            this.catalogName = catalogName;
            this.defaultRoute = defaultRoute;
            this.title = title;
            this.routes = routes;
        }
        return CatalogInitResponse;
    }());
    SnappetChallenge.CatalogInitResponse = CatalogInitResponse;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=catalogInitResponse.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var CatalogRegistry = /** @class */ (function () {
        function CatalogRegistry() {
            var _this = this;
            this.catalogs = [];
            this.registerCatalog = function (catalog) {
                _this.catalogs.push(catalog);
            };
            this.getCatalogs = function () {
                return _this.catalogs;
            };
        }
        return CatalogRegistry;
    }());
    SnappetChallenge.CatalogRegistry = CatalogRegistry;
    SnappetChallenge.catalogRegistry = new CatalogRegistry();
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=catalogRegistry.js.map
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
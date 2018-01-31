var SnappetChallenge;
(function (SnappetChallenge) {
    var Root;
    (function (Root) {
        var SubAppInitResponse = /** @class */ (function () {
            function SubAppInitResponse(catalogName) {
                this.catalogName = catalogName;
            }
            return SubAppInitResponse;
        }());
        Root.SubAppInitResponse = SubAppInitResponse;
        var EmptyApp = /** @class */ (function () {
            function EmptyApp(catalogName) {
                var _this = this;
                this.catalogName = catalogName;
                this.init = function (root) {
                    return _this;
                };
            }
            return EmptyApp;
        }());
        Root.EmptyApp = EmptyApp;
    })(Root = SnappetChallenge.Root || (SnappetChallenge.Root = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=subApp.js.map
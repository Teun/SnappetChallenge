var SnappetChallenge;
(function (SnappetChallenge) {
    var Services = /** @class */ (function () {
        function Services() {
            this.dialogManager = new SnappetChallenge.DialogManager();
            this.httpClient = new SnappetChallenge.JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new SnappetChallenge.ApiUriConfig();
            this.apiClient = new SnappetChallenge.ApiClient(this.httpClient, this.apiUriConfig);
        }
        return Services;
    }());
    SnappetChallenge.Services = Services;
    var DateTimeProvider = /** @class */ (function () {
        function DateTimeProvider() {
        }
        return DateTimeProvider;
    }());
    SnappetChallenge.DateTimeProvider = DateTimeProvider;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=services.js.map
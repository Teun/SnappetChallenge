var SnappetChallenge;
(function (SnappetChallenge) {
    var Services = /** @class */ (function () {
        function Services() {
            this.dialogManager = new SnappetChallenge.DialogManager();
            this.httpClient = new SnappetChallenge.JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new SnappetChallenge.ApiUrlConfig();
            this.apiClient = new SnappetChallenge.ApiClient(this.httpClient, this.apiUriConfig);
            this.dateTimeProvider = new SnappetChallenge.DateTimeProvider();
            this.dateRangeFilterBuilder = new SnappetChallenge.DateRangeFilterBuilder();
            this.dateAliasConverter = new SnappetChallenge.DateAliasConverter(this.dateTimeProvider);
        }
        return Services;
    }());
    SnappetChallenge.Services = Services;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=services.js.map
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
            var _this = this;
            this.getCurrentUtc = function () {
                return moment("2015-03-24T11:30:00Z").toDate();
            };
            this.getCurrent = function () {
                return moment.utc(_this.getCurrentUtc()).local().toDate();
            };
        }
        return DateTimeProvider;
    }());
    SnappetChallenge.DateTimeProvider = DateTimeProvider;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=services.js.map
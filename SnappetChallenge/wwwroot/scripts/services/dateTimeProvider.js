var SnappetChallenge;
(function (SnappetChallenge) {
    var DateTimeProvider = /** @class */ (function () {
        function DateTimeProvider() {
            var _this = this;
            this.getCurrentUtc = function () {
                return moment("2015-03-24T11:30:00Z").toDate();
            };
            this.getCurrent = function () {
                return moment.utc(_this.getCurrentUtc()).local().toDate();
            };
            this.getTodaysDate = function () {
                return SnappetChallenge.Helpers.truncateTime(_this.getCurrent());
            };
        }
        return DateTimeProvider;
    }());
    SnappetChallenge.DateTimeProvider = DateTimeProvider;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateTimeProvider.js.map
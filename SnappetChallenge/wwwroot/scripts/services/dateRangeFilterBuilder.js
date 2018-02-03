var SnappetChallenge;
(function (SnappetChallenge) {
    var DateRangeFilterBuilder = /** @class */ (function () {
        function DateRangeFilterBuilder() {
            this.getFilterForDate = function (date) {
                var from = SnappetChallenge.Helpers.convertToUtc(date);
                var to = SnappetChallenge.Helpers.convertToUtc(moment(date).add("24", "hours").toDate());
                return {
                    from: moment(from).format("YYYY-MM-DDTHH:mm:ss[Z]"),
                    to: moment(to).format("YYYY-MM-DDTHH:mm:ss[Z]")
                };
            };
        }
        return DateRangeFilterBuilder;
    }());
    SnappetChallenge.DateRangeFilterBuilder = DateRangeFilterBuilder;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateRangeFilterBuilder.js.map
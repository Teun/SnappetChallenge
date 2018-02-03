var SnappetChallenge;
(function (SnappetChallenge) {
    var DateAliasConverter = /** @class */ (function () {
        function DateAliasConverter(dateTimeProvider) {
            this.getDateFromAlias = function (dateAlias) {
                var today = dateTimeProvider.getTodaysDate();
                var date = dateAlias === "today" ? today : new Date(dateAlias);
                return date;
            };
            this.getDateAlias = function (date) {
                if (date.getTime() === dateTimeProvider.getTodaysDate().getTime())
                    return "today";
                else
                    return moment(date).format("YYYY-MM-DD");
            };
        }
        return DateAliasConverter;
    }());
    SnappetChallenge.DateAliasConverter = DateAliasConverter;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateAliasConverter.js.map
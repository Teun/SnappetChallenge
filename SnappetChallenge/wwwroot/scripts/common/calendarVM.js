var SnappetChallenge;
(function (SnappetChallenge) {
    var CalendarVM = /** @class */ (function () {
        function CalendarVM(dateTimeProvider) {
            var _this = this;
            this.date = ko.observable();
            this.formattedDate = ko.computed(function () {
                if (_this.date())
                    return moment(_this.date()).format("MMMM Do");
                return "";
            });
            this.maxSelectableDate = moment(dateTimeProvider.getTodaysDate()).format("YYYY-MM-DD");
        }
        return CalendarVM;
    }());
    SnappetChallenge.CalendarVM = CalendarVM;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=calendarVM.js.map
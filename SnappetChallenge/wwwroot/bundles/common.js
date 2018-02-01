var SnappetChallenge;
(function (SnappetChallenge) {
    var CalendarVM = /** @class */ (function () {
        function CalendarVM(dateTimeProvider) {
            var _this = this;
            this.date = ko.observable();
            this.formattedDate = ko.computed(function () {
                return moment(_this.date()).format("MMMM Do");
            });
            this.maxSelectableDate = moment(dateTimeProvider.getTodaysDate()).format("YYYY-MM-DD");
        }
        return CalendarVM;
    }());
    SnappetChallenge.CalendarVM = CalendarVM;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=calendarVM.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var Helpers = /** @class */ (function () {
        function Helpers() {
        }
        Helpers.convertToUtc = function (date) {
            return moment(date).add(moment(date).utcOffset(), "m").utc().toDate();
        };
        Helpers.convertToLocal = function (date) {
            return moment(date).subtract(moment(date).utcOffset(), "m").local().toDate();
        };
        Helpers.truncateTime = function (date) {
            var newDate = new Date(date);
            newDate.setHours(0, 0, 0, 0);
            return newDate;
        };
        return Helpers;
    }());
    SnappetChallenge.Helpers = Helpers;
    var KoExtensions = /** @class */ (function () {
        function KoExtensions() {
        }
        KoExtensions.init = function () {
            ko.bindingHandlers["inlineDatepicker"] = {
                init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                    $(element).datepicker({ format: "yyyy-mm-dd" });
                    var value = valueAccessor();
                    if (ko.isObservable(value)) {
                        $(element).on("changeDate", function () {
                            var datePickerDate = $(element).datepicker("getDate");
                            value(datePickerDate);
                        });
                    }
                },
                update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                    $(element).datepicker("setDate", ko.unwrap(valueAccessor()));
                }
            };
        };
        return KoExtensions;
    }());
    SnappetChallenge.KoExtensions = KoExtensions;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=koExtensions.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var ProgressVM = /** @class */ (function () {
        function ProgressVM(progress) {
            this.progress = progress;
            var maxProgress = 30;
            var absoluteProgress = Math.abs(progress);
            var boundedProgress = Math.min(maxProgress, absoluteProgress);
            this.progressBarWidth = boundedProgress / maxProgress * 100;
            this.isNegative = progress < 0;
            this.formattedValue = (((progress * 100) | 0) / 100).toString();
        }
        return ProgressVM;
    }());
    SnappetChallenge.ProgressVM = ProgressVM;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=progressVM.js.map
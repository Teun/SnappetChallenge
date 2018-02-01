var SnappetChallenge;
(function (SnappetChallenge) {
    var Helpers = /** @class */ (function () {
        function Helpers() {
        }
        Helpers.convertToUtc = function (date) {
            return moment(date).add(moment(date).utcOffset(), 'm').utc().toDate();
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
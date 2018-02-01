module SnappetChallenge {
    export class Helpers {
        static convertToUtc(date: Date) {
            return moment(date).add(moment(date).utcOffset(), "m").utc().toDate();
        }

        static convertToLocal(date: Date) {
            return moment(date).subtract(moment(date).utcOffset(), "m").local().toDate();
        }

        static truncateTime(date: Date) {
            var newDate = new Date(date);
            newDate.setHours(0, 0, 0, 0);
            return newDate;
        }
    }

    export class KoExtensions {
        static init() {
            ko.bindingHandlers["inlineDatepicker"] = {
                init: (element, valueAccessor, allBindings, viewModel, bindingContext) => {
                    $(element).datepicker({format: "yyyy-mm-dd"});
                    var value = valueAccessor();
                    if (ko.isObservable(value)) {
                        $(element).on("changeDate",
                            () => {
                                const datePickerDate = $(element).datepicker("getDate");
                                value(datePickerDate);
                            });
                    }
                },
                update: (element, valueAccessor, allBindings, viewModel, bindingContext) => {
                    $(element).datepicker("setDate", ko.unwrap(valueAccessor()));
                }
            };
        }
    }
}
module SnappetChallenge {
    export class Helpers {
        static convertToUtc(date: Date) {
            return moment(date).add(moment(date).utcOffset(), 'm').utc().toDate();
        }
    }

    export class KoExtensions {
        static init() {
            ko.bindingHandlers["inlineDatepicker"] = {
                init: (element, valueAccessor, allBindings, viewModel, bindingContext) => {
                    $(element).datepicker();
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
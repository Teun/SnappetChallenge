module SnappetChallenge {
    import DateRangeFilter = Models.DateRangeFilter;

    export interface IDateRangeFilterBuilder {
        getFilterForDate: (date: Date) => DateRangeFilter;
    }

    export class DateRangeFilterBuilder implements IDateRangeFilterBuilder {
        getFilterForDate: (date: Date) => DateRangeFilter;
        constructor() {
            this.getFilterForDate = (date: Date) => {
                var from = Helpers.convertToUtc(date);
                var to = Helpers.convertToUtc(moment(date).add("24", "hours").toDate());
                return {
                    from: moment(from).format("YYYY-MM-DDTHH:mm:ss[Z]"),
                    to: moment(to).format("YYYY-MM-DDTHH:mm:ss[Z]")
                }
            }
        }
    }
}
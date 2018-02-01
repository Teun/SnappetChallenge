module SnappetChallenge {
    export class CalendarVM {
        date = ko.observable<Date>();
        maxSelectableDate: string;

        formattedDate: KnockoutComputed<string>;

        constructor(dateTimeProvider: IDateTimeProvider) {
            this.formattedDate = ko.computed(() => {
                return moment(this.date()).format("MMMM Do");
            });

            this.maxSelectableDate = moment(dateTimeProvider.getTodaysDate()).format("YYYY-MM-DD");
        }
    }
}
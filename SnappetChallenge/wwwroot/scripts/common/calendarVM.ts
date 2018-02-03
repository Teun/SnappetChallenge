module SnappetChallenge {
    export class CalendarVM {
        date = ko.observable<Date>();
        maxSelectableDate: string;

        formattedDate: KnockoutComputed<string>;

        constructor(dateTimeProvider: IDateTimeProvider) {
            this.formattedDate = ko.computed(() => {
                if (this.date())
                    return moment(this.date()).format("MMMM Do");
                return "";
            });

            this.maxSelectableDate = moment(dateTimeProvider.getTodaysDate()).format("YYYY-MM-DD");
        }
    }
}
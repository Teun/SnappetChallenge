module SnappetChallenge {
    export interface IDateAliasConverter {
        getDateFromAlias: (dateAlias: string) => Date;
        getDateAlias: (date: Date) => string;
    }

    export class DateAliasConverter implements IDateAliasConverter {
        getDateFromAlias: (dateAlias: string) => Date;
        getDateAlias: (date: Date) => string;

        constructor(dateTimeProvider: IDateTimeProvider) {
            this.getDateFromAlias = (dateAlias: string) => {
                const today = dateTimeProvider.getTodaysDate();
                const date = dateAlias === "today" ? today : new Date(dateAlias);
                return date;
            }

            this.getDateAlias = (date: Date) => {
                if (date.getTime() === dateTimeProvider.getTodaysDate().getTime())
                    return "today";
                else
                    return moment(date).format("YYYY-MM-DD");
            }
        }
    }
}
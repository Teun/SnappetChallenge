module SnappetChallenge {
    export interface IDateTimeProvider {
        getCurrent: () => Date;
        getCurrentUtc: () => Date;
        getTodaysDate: () => Date;
    }

    export class DateTimeProvider implements IDateTimeProvider {
        getCurrent: () => Date;
        getCurrentUtc: () => Date;
        getTodaysDate: () => Date;

        constructor() {
            this.getCurrentUtc = () => {
                return moment("2015-03-24T11:30:00Z").toDate();
            }

            this.getCurrent = () => {
                return moment.utc(this.getCurrentUtc()).local().toDate();
            }

            this.getTodaysDate = () => {
                return Helpers.truncateTime(this.getCurrent());
            }
        }
    }
}
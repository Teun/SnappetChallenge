module SnappetChallenge.Pupils {
    import UserCard = Models.UserCard;

    export class PupilsListVM implements IViewModel {
        pupils = ko.observableArray<UserCard>([]);
        loading = ko.observable(false);
        initialized = ko.observable(false);
        calendar: CalendarVM;

        init: (params: { date: string }) => void;
        loadData: (date: Date) => void;
        clear: () => void;

        constructor(dateTimeProvider: IDateTimeProvider,
            dateRangeFilterBuilder: IDateRangeFilterBuilder,
            dateAliasConverter: IDateAliasConverter,
            apiClient: IApiClient,
            router: SammyInst) {
            this.calendar = new CalendarVM(dateTimeProvider);

            this.init = (params: { date: string }) => {
                this.initialized(false);
                const date = dateAliasConverter.getDateFromAlias(params.date);
                this.calendar.date(date);
                this.clear();
                this.loadData(date);
                this.initialized(true);
            }

            this.clear = () => {
                this.pupils([]);
            }

            this.loadData = (date: Date) => {
                var filter = dateRangeFilterBuilder.getFilterForDate(date);
                this.loading(true);
                apiClient.getUsers(filter,
                    (data) => {
                        if (date.getTime() === this.calendar.date().getTime())
                            this.pupils(data.map(u => new UserCard(
                                u.userId,
                                u.name,
                                u.averageProgress,
                                `/image/${u.imageId}`,
                                dateAliasConverter.getDateAlias(this.calendar.date()))));
                    }).always(() => this.loading(false));
            };
            
            this.calendar.date.subscribe((newValue: Date) => {
                if (this.initialized()) {
                    var dateAlias = dateAliasConverter.getDateAlias(newValue);
                    router.setLocation(`#/pupils/${dateAlias}`);
                }
            });
        }
    }
}
module SnappetChallenge.LearningObjectives {
    import LearningObjective = Models.LearningObjective;
    import UserForLearningObjective = Models.UserForLearningObjective;
    import UserCard = Models.UserCard;

    export class ClassWorkVM implements IViewModel {
        learningObjectives = ko.observableArray<LearningObjectiveListItemVM>([]);
        loading = ko.observable(false);
        initialized = ko.observable(false);
        calendar: CalendarVM;

        init: (params: { date: string }) => void;
        loadData: (date: Date) => void;
        clear: () => void;

        constructor(dateTimeProvider: IDateTimeProvider,
            apiClient: IApiClient,
            dateRangeFilterBuilder: IDateRangeFilterBuilder,
            dateAliasConverter: IDateAliasConverter,
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
                this.learningObjectives([]);
            };

            this.loadData = (date: Date) => {
                var filter = dateRangeFilterBuilder.getFilterForDate(date);
                this.loading(true);
                apiClient.getLearningObjectives(filter,
                    (data) => {
                        if (date.getTime() === this.calendar.date().getTime())
                            this.learningObjectives(data
                                .map(o => new LearningObjectiveListItemVM(o, dateAliasConverter.getDateAlias(this.calendar.date()))));
                    }).always(() => this.loading(false));
            };

            this.calendar.date.subscribe((newValue: Date) => {
                if (this.initialized()) {
                    var dateAlias = dateAliasConverter.getDateAlias(newValue);
                    router.setLocation(`#/class-work/${dateAlias}`);
                }
            });
        }
    }

    export class LearningObjectiveListItemVM {
        name = ko.observable<string>();
        domain = ko.observable<string>();
        subject = ko.observable<string>();
        averageProgress = ko.observable<number>();
        users = ko.observableArray<UserForLearningObjectivListItemVM>([]);
        expanded = ko.observable<boolean>(false);

        toggle: () => void;
        setData: (data: LearningObjective) => void;

        constructor(initData: LearningObjective, date: string) {
            this.setData = (data: LearningObjective) => {
                this.name(data.name);
                this.domain(data.domain);
                this.subject(data.subject);
                this.averageProgress(data.averageProgress);
                this.users(data.users.map(u => new UserForLearningObjectivListItemVM(u, date)));
            };

            this.toggle = () => {
                this.expanded(!this.expanded());
            };

            this.setData(initData);
        }
    }

    export class UserForLearningObjectivListItemVM {
        userId = ko.observable<number>();
        name = ko.observable<string>();
        overallProgress = ko.observable<number>();
        imageId = ko.observable<number>();

        userCardData: KnockoutComputed<UserCard>;

        setData: (data: UserForLearningObjective) => void;

        constructor(initData: UserForLearningObjective, date: string) {
            this.setData = (data: UserForLearningObjective) => {
                this.userId(data.userId);
                this.name(data.name);
                this.imageId(data.imageId);
                this.overallProgress(data.overallProgress);
            };

            this.userCardData = ko.computed(() => {
                return new UserCard(this.userId(), this.name(), this.overallProgress(), `/image/${this.imageId()}`, date);
            });

            this.setData(initData);
        }
    }
}
module SnappetChallenge.LearningObjectives {
    import LearningObjective = Models.LearningObjective;
    import UserForLearningObjective = Models.UserForLearningObjective;
    import UserCard = Models.UserCard;

    export class classWorkVM implements IViewModel {
        learningObjectives = ko.observableArray<LearningObjectiveListItemVM>([]);
        date = ko.observable<Date>();
        loading = ko.observable(false);
        initialized = ko.observable(false);

        formattedDate: KnockoutComputed<string>;
        init: (params: { date: string }) => void;
        loadData: (date: Date) => void;
        clear: () => void;

        constructor(dateTimeProvider: IDateTimeProvider,
            apiClient: IApiClient,
            router: SammyInst) {
            this.init = (params: { date: string }) => {
                this.initialized(false);
                const today = dateTimeProvider.getCurrent();
                today.setHours(0, 0, 0, 0);
                const date = params.date === "today" ? today : new Date(params.date);
                this.date(date);
                this.clear();
                this.loadData(date);
                this.initialized(true);
            }

            this.formattedDate = ko.computed(() => {
                return moment(this.date()).format("MMMM Do");
            });

            this.clear = () => {
                this.learningObjectives([]);
            };

            this.loadData = (date: Date) => {
                var from = Helpers.convertToUtc(date);
                var to = Helpers.convertToUtc(moment(date).add("24", "hours").toDate());
                this.loading(true);
                var loadingDate = this.date();
                apiClient.getLearningObjectives(from, to,
                    (data) => {
                        if (loadingDate == this.date())
                            this.learningObjectives(data.map(o => new LearningObjectiveListItemVM(o)));
                    }).always(() => this.loading(false));
            };

            this.date.subscribe((newValue: Date) => {
                if (this.initialized()) {
                    router.setLocation("#/class-work/" + moment(newValue).format("YYYY-MM-DD"));
                    this.loadData(this.date());
                }
                //window.location.href = "#/class-work/" + moment(newValue).format("YYYY-MM-DD")
                
            })
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

        constructor(initData: LearningObjective) {
            this.setData = (data: LearningObjective) => {
                this.name(data.name);
                this.domain(data.domain);
                this.subject(data.subject);
                this.averageProgress(data.averageProgress);
                this.users(data.users.map(u => new UserForLearningObjectivListItemVM(u)));
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

        constructor(initData: UserForLearningObjective) {
            this.setData = (data: UserForLearningObjective) => {
                this.userId(data.userId);
                this.name(data.name);
                this.imageId(data.imageId);
                this.overallProgress(data.overallProgress);
            };

            this.userCardData = ko.computed(() => {
                return new UserCard(this.userId(), this.name(), this.overallProgress(), `/image/${this.imageId()}`);
            });

            this.setData(initData);
        }
    }
}
module SnappetChallenge.Pupils {
    import UserDetails = Models.UserDetails;
    import LearningObjectiveForUserDetails = Models.LearningObjectiveForUserDetails;
    import SubmittedAnswer = Models.SubmittedAnswer;

    export class PupilDetailsVM implements IViewModel {
        userId = ko.observable<number>();
        name = ko.observable<string>();
        imageId = ko.observable<number>();
        averageProgress = ko.observable<number>();
        learningObjectives = ko.observableArray<LearningObjectiveForUserDetailsVM>([]);
        loading = ko.observable(false);
        initialized = ko.observable(false);
        calendar: CalendarVM;

        imageUrl: KnockoutComputed<string>;

        setData: (data: UserDetails) => void;
        init: (params: { userId: number, date: string }) => void;
        loadData: (userId: number, date: Date) => void;
        clear: () => void;

        constructor(dateTimeProvider: IDateTimeProvider,
            dateRangeFilterBuilder: IDateRangeFilterBuilder,
            dateAliasConverter: IDateAliasConverter,
            apiClient: IApiClient,
            router: SammyInst) {

            this.calendar = new CalendarVM(dateTimeProvider);

            this.imageUrl = ko.computed(() => {
                if (this.imageId())
                    return `/image/${this.imageId()}`;
                return null;
            });

            this.setData = (data: UserDetails) => {
                this.userId(data.userId);
                this.name(data.name);
                this.imageId(data.imageId);
                this.averageProgress(data.averageProgress);
                this.learningObjectives(data.learningObjectives
                    .map(lo => new LearningObjectiveForUserDetailsVM(lo)));
            }

            this.init = (params: { userId: number, date: string }) => {
                this.initialized(false);
                const date = dateAliasConverter.getDateFromAlias(params.date);
                this.calendar.date(date);
                this.clear();
                this.loadData(params.userId, date);
                this.initialized(true);
            }

            this.clear = () => {
                this.userId(null);
                this.name(null);
                this.imageId(null);
                this.averageProgress(null);
                this.learningObjectives([]);
            }

            this.loadData = (userId: number, date: Date) => {
                var filter = dateRangeFilterBuilder.getFilterForDate(date);
                this.loading(true);
                apiClient.getUserDetails(userId, filter,
                    (data) => {
                        if (date.getTime() === this.calendar.date().getTime())
                            this.setData(data);
                    }).always(() => this.loading(false));
            }

            this.calendar.date.subscribe((newValue: Date) => {
                if (this.initialized() && this.userId()) {
                    var dateAlias = dateAliasConverter.getDateAlias(newValue);
                    router.setLocation(`#/pupils/${this.userId()}/${dateAlias}`);
                }
            });
        }
    }

    export class LearningObjectiveForUserDetailsVM {
        name = ko.observable<string>();
        domain = ko.observable<string>();
        subject = ko.observable<string>();
        overallProgress = ko.observable<number>();
        answers = ko.observableArray<SubmittedAnswer>([]);
        expanded = ko.observable(false);

        correctAnswersCount: KnockoutComputed<number>;
        incorrectAnswersCount: KnockoutComputed<number>;

        toggle: () => void;
        setData: (data: LearningObjectiveForUserDetails) => void;
        formattedSubmitTime: (submitTime: Date) => string;

        constructor(initialData: LearningObjectiveForUserDetails) {
            this.setData = (data: LearningObjectiveForUserDetails) => {
                this.name(data.name);
                this.domain(data.domain);
                this.subject(data.subject);
                this.overallProgress(data.overallProgress);
                this.answers(data.answers);
            }

            this.formattedSubmitTime = (submitTime: Date) => {
                return moment(Helpers.convertToLocal(submitTime)).format("HH:mm:ss");
            }

            this.correctAnswersCount = ko.computed(() => {
                return this.answers().filter(a => a.correct).length;
            });

            this.incorrectAnswersCount = ko.computed(() => {
                return this.answers().filter(a => !a.correct).length;
            });

            this.setData(initialData);

            this.toggle = () => {
                this.expanded(!this.expanded());
            };
        }
    }
}
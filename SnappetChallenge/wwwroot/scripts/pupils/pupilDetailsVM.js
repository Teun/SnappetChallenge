var SnappetChallenge;
(function (SnappetChallenge) {
    var Pupils;
    (function (Pupils) {
        var PupilDetailsVM = /** @class */ (function () {
            function PupilDetailsVM(dateTimeProvider, dateRangeFilterBuilder, dateAliasConverter, apiClient, router) {
                var _this = this;
                this.userId = ko.observable();
                this.name = ko.observable();
                this.imageId = ko.observable();
                this.averageProgress = ko.observable();
                this.learningObjectives = ko.observableArray([]);
                this.loading = ko.observable(false);
                this.initialized = ko.observable(false);
                this.calendar = new SnappetChallenge.CalendarVM(dateTimeProvider);
                this.imageUrl = ko.computed(function () {
                    if (_this.imageId())
                        return "/image/" + _this.imageId();
                    return null;
                });
                this.setData = function (data) {
                    _this.userId(data.userId);
                    _this.name(data.name);
                    _this.imageId(data.imageId);
                    _this.averageProgress(data.averageProgress);
                    _this.learningObjectives(data.learningObjectives
                        .map(function (lo) { return new LearningObjectiveForUserDetailsVM(lo); }));
                };
                this.init = function (params) {
                    console.log("init starts");
                    _this.initialized(false);
                    var date = dateAliasConverter.getDateFromAlias(params.date);
                    console.log("setting date");
                    _this.calendar.date(date);
                    console.log("clearing data");
                    _this.clear();
                    console.log("loading data for", params.userId, date);
                    _this.loadData(params.userId, date);
                    _this.initialized(true);
                    console.log("init completes");
                };
                this.clear = function () {
                    _this.userId(null);
                    _this.name(null);
                    _this.imageId(null);
                    _this.averageProgress(null);
                    _this.learningObjectives([]);
                };
                this.loadData = function (userId, date) {
                    var filter = dateRangeFilterBuilder.getFilterForDate(date);
                    _this.loading(true);
                    apiClient.getUserDetails(userId, filter, function (data) {
                        console.log("data loaded");
                        if (date.getTime() === _this.calendar.date().getTime()) {
                            console.log("setting up the data");
                            _this.setData(data);
                        }
                    }).always(function () { return _this.loading(false); });
                };
                this.calendar.date.subscribe(function (newValue) {
                    console.log("date updated", newValue);
                    if (_this.initialized() && _this.userId()) {
                        var dateAlias = dateAliasConverter.getDateAlias(newValue);
                        console.log("reloading page");
                        router.setLocation("#/pupils/" + _this.userId() + "/" + dateAlias);
                    }
                });
            }
            return PupilDetailsVM;
        }());
        Pupils.PupilDetailsVM = PupilDetailsVM;
        var LearningObjectiveForUserDetailsVM = /** @class */ (function () {
            function LearningObjectiveForUserDetailsVM(initialData) {
                var _this = this;
                this.name = ko.observable();
                this.domain = ko.observable();
                this.subject = ko.observable();
                this.overallProgress = ko.observable();
                this.answers = ko.observableArray([]);
                this.expanded = ko.observable(false);
                this.setData = function (data) {
                    _this.name(data.name);
                    _this.domain(data.domain);
                    _this.subject(data.subject);
                    _this.overallProgress(data.overallProgress);
                    _this.answers(data.answers);
                };
                this.formattedSubmitTime = function (submitTime) {
                    return moment(SnappetChallenge.Helpers.convertToLocal(submitTime)).format("HH:mm:ss");
                };
                this.correctAnswersCount = ko.computed(function () {
                    return _this.answers().filter(function (a) { return a.correct; }).length;
                });
                this.incorrectAnswersCount = ko.computed(function () {
                    return _this.answers().filter(function (a) { return !a.correct; }).length;
                });
                this.setData(initialData);
                this.toggle = function () {
                    _this.expanded(!_this.expanded());
                };
            }
            return LearningObjectiveForUserDetailsVM;
        }());
        Pupils.LearningObjectiveForUserDetailsVM = LearningObjectiveForUserDetailsVM;
    })(Pupils = SnappetChallenge.Pupils || (SnappetChallenge.Pupils = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=pupilDetailsVM.js.map
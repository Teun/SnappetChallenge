var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var UserCard = SnappetChallenge.Models.UserCard;
        var classWorkVM = /** @class */ (function () {
            function classWorkVM(dateTimeProvider, apiClient, router) {
                var _this = this;
                this.learningObjectives = ko.observableArray([]);
                this.date = ko.observable();
                this.loading = ko.observable(false);
                this.initialized = ko.observable(false);
                this.init = function (params) {
                    _this.initialized(false);
                    var today = SnappetChallenge.Helpers.truncateTime(dateTimeProvider.getCurrent());
                    var date = params.date === "today" ? today : new Date(params.date);
                    _this.date(date);
                    _this.clear();
                    _this.loadData(date);
                    _this.initialized(true);
                };
                this.formattedDate = ko.computed(function () {
                    return moment(_this.date()).format("MMMM Do");
                });
                this.clear = function () {
                    _this.learningObjectives([]);
                };
                this.loadData = function (date) {
                    var from = SnappetChallenge.Helpers.convertToUtc(date);
                    var to = SnappetChallenge.Helpers.convertToUtc(moment(date).add("24", "hours").toDate());
                    _this.loading(true);
                    var loadingDate = _this.date();
                    apiClient.getLearningObjectives(from, to, function (data) {
                        if (loadingDate == _this.date())
                            _this.learningObjectives(data.map(function (o) { return new LearningObjectiveListItemVM(o); }));
                    }).always(function () { return _this.loading(false); });
                };
                this.date.subscribe(function (newValue) {
                    if (_this.initialized()) {
                        router.setLocation("#/class-work/" + moment(newValue).format("YYYY-MM-DD"));
                        _this.loadData(_this.date());
                    }
                });
                this.maxSelectableDate = moment(SnappetChallenge.Helpers.truncateTime(dateTimeProvider.getCurrent())).format("YYYY-MM-DD");
            }
            return classWorkVM;
        }());
        LearningObjectives.classWorkVM = classWorkVM;
        var LearningObjectiveListItemVM = /** @class */ (function () {
            function LearningObjectiveListItemVM(initData) {
                var _this = this;
                this.name = ko.observable();
                this.domain = ko.observable();
                this.subject = ko.observable();
                this.averageProgress = ko.observable();
                this.users = ko.observableArray([]);
                this.expanded = ko.observable(false);
                this.setData = function (data) {
                    _this.name(data.name);
                    _this.domain(data.domain);
                    _this.subject(data.subject);
                    _this.averageProgress(data.averageProgress);
                    _this.users(data.users.map(function (u) { return new UserForLearningObjectivListItemVM(u); }));
                };
                this.toggle = function () {
                    _this.expanded(!_this.expanded());
                };
                this.setData(initData);
            }
            return LearningObjectiveListItemVM;
        }());
        LearningObjectives.LearningObjectiveListItemVM = LearningObjectiveListItemVM;
        var UserForLearningObjectivListItemVM = /** @class */ (function () {
            function UserForLearningObjectivListItemVM(initData) {
                var _this = this;
                this.userId = ko.observable();
                this.name = ko.observable();
                this.overallProgress = ko.observable();
                this.imageId = ko.observable();
                this.setData = function (data) {
                    _this.userId(data.userId);
                    _this.name(data.name);
                    _this.imageId(data.imageId);
                    _this.overallProgress(data.overallProgress);
                };
                this.userCardData = ko.computed(function () {
                    return new UserCard(_this.userId(), _this.name(), _this.overallProgress(), "/image/" + _this.imageId());
                });
                this.setData(initData);
            }
            return UserForLearningObjectivListItemVM;
        }());
        LearningObjectives.UserForLearningObjectivListItemVM = UserForLearningObjectivListItemVM;
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=classWorkVM.js.map
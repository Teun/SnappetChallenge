var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var UserCard = SnappetChallenge.Models.UserCard;
        var LearningObjectivesListVM = /** @class */ (function () {
            function LearningObjectivesListVM(dateTimeProvider, apiClient) {
                var _this = this;
                this.learningObjectives = ko.observableArray([]);
                this.date = ko.observable();
                this.loading = ko.observable(false);
                this.init = function (params) {
                    var today = dateTimeProvider.getCurrent();
                    today.setHours(0, 0, 0, 0);
                    var date = params.date === "today" ? today : new Date(params.date);
                    _this.date(date);
                    _this.clear();
                    _this.loadData(date);
                };
                this.formattedDate = ko.computed(function () {
                    return moment(_this.date()).format("MMMM Do");
                });
                this.clear = function () {
                    _this.learningObjectives([]);
                };
                this.loadData = function (date) {
                    var from = moment(date).utc().toDate();
                    var to = moment(date).utc().add("24", "hours").toDate();
                    _this.loading(true);
                    apiClient.getLearningObjectives(from, to, function (data) {
                        _this.learningObjectives(data.map(function (o) { return new LearningObjectiveListItemVM(o); }));
                    }).always(function () { return _this.loading(false); });
                };
            }
            return LearningObjectivesListVM;
        }());
        LearningObjectives.LearningObjectivesListVM = LearningObjectivesListVM;
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
//# sourceMappingURL=learningObjectivesVM.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var LearningObjectivesCatalog = /** @class */ (function () {
            function LearningObjectivesCatalog() {
                this.init = function (services) {
                    var learningObjectivesViewModel = new LearningObjectives.LearningObjectivesListVM(services.dateTimeProvider, services.apiClient);
                    var learningObjectivesTemplate = new SnappetChallenge.TemplateForm("classWork", learningObjectivesViewModel);
                    return new SnappetChallenge.CatalogInitResponse("learningObjectives", "#/class-work/today", "Class work", [
                        new SnappetChallenge.Route("#/class-work/:date", learningObjectivesTemplate)
                    ]);
                };
            }
            return LearningObjectivesCatalog;
        }());
        LearningObjectives.LearningObjectivesCatalog = LearningObjectivesCatalog;
        if (SnappetChallenge.catalogRegistry) {
            SnappetChallenge.catalogRegistry.registerCatalog(new LearningObjectivesCatalog());
        }
        else {
            throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
        }
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=learningObjectivesCatalog.js.map
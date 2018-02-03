var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var ClassWorkCatalog = /** @class */ (function () {
            function ClassWorkCatalog() {
                this.init = function (services, router) {
                    var learningObjectivesViewModel = new LearningObjectives.ClassWorkVM(services.dateTimeProvider, services.apiClient, services.dateRangeFilterBuilder, services.dateAliasConverter, router);
                    var learningObjectivesTemplate = new SnappetChallenge.TemplateForm("classWork", learningObjectivesViewModel);
                    return new SnappetChallenge.CatalogInitResponse("classWork", "#/class-work/today", "Class work", [
                        new SnappetChallenge.Route("#/class-work/:date", learningObjectivesTemplate)
                    ]);
                };
            }
            return ClassWorkCatalog;
        }());
        LearningObjectives.ClassWorkCatalog = ClassWorkCatalog;
        if (SnappetChallenge.catalogRegistry) {
            SnappetChallenge.catalogRegistry.registerCatalog(new ClassWorkCatalog());
        }
        else {
            throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
        }
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=classWorkCatalog.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var UserCard = SnappetChallenge.Models.UserCard;
        var ClassWorkVM = /** @class */ (function () {
            function ClassWorkVM(dateTimeProvider, apiClient, dateRangeFilterBuilder, dateAliasConverter, router) {
                var _this = this;
                this.learningObjectives = ko.observableArray([]);
                this.loading = ko.observable(false);
                this.initialized = ko.observable(false);
                this.calendar = new SnappetChallenge.CalendarVM(dateTimeProvider);
                this.init = function (params) {
                    _this.initialized(false);
                    var date = dateAliasConverter.getDateFromAlias(params.date);
                    _this.calendar.date(date);
                    _this.clear();
                    _this.loadData(date);
                    _this.initialized(true);
                };
                this.clear = function () {
                    _this.learningObjectives([]);
                };
                this.loadData = function (date) {
                    var filter = dateRangeFilterBuilder.getFilterForDate(date);
                    _this.loading(true);
                    apiClient.getLearningObjectives(filter, function (data) {
                        if (date.getTime() === _this.calendar.date().getTime())
                            _this.learningObjectives(data
                                .map(function (o) { return new LearningObjectiveListItemVM(o, dateAliasConverter.getDateAlias(_this.calendar.date())); }));
                    }).always(function () { return _this.loading(false); });
                };
                this.calendar.date.subscribe(function (newValue) {
                    if (_this.initialized()) {
                        var dateAlias = dateAliasConverter.getDateAlias(newValue);
                        router.setLocation("#/class-work/" + dateAlias);
                    }
                });
            }
            return ClassWorkVM;
        }());
        LearningObjectives.ClassWorkVM = ClassWorkVM;
        var LearningObjectiveListItemVM = /** @class */ (function () {
            function LearningObjectiveListItemVM(initData, date) {
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
                    _this.users(data.users.map(function (u) { return new UserForLearningObjectivListItemVM(u, date); }));
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
            function UserForLearningObjectivListItemVM(initData, date) {
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
                    return new UserCard(_this.userId(), _this.name(), _this.overallProgress(), "/image/" + _this.imageId(), date);
                });
                this.setData(initData);
            }
            return UserForLearningObjectivListItemVM;
        }());
        LearningObjectives.UserForLearningObjectivListItemVM = UserForLearningObjectivListItemVM;
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=classWorkVM.js.map
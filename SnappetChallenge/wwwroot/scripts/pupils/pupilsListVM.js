var SnappetChallenge;
(function (SnappetChallenge) {
    var Pupils;
    (function (Pupils) {
        var UserCard = SnappetChallenge.Models.UserCard;
        var PupilsListVM = /** @class */ (function () {
            function PupilsListVM(dateTimeProvider, dateRangeFilterBuilder, dateAliasConverter, apiClient, router) {
                var _this = this;
                this.pupils = ko.observableArray([]);
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
                    _this.pupils([]);
                };
                this.loadData = function (date) {
                    var filter = dateRangeFilterBuilder.getFilterForDate(date);
                    _this.loading(true);
                    apiClient.getUsers(filter, function (data) {
                        if (date.getTime() === _this.calendar.date().getTime())
                            _this.pupils(data.map(function (u) { return new UserCard(u.userId, u.name, u.averageProgress, "/image/" + u.imageId, dateAliasConverter.getDateAlias(_this.calendar.date())); }));
                    }).always(function () { return _this.loading(false); });
                };
                this.calendar.date.subscribe(function (newValue) {
                    if (_this.initialized()) {
                        var dateAlias = dateAliasConverter.getDateAlias(newValue);
                        router.setLocation("#/pupils/" + dateAlias);
                    }
                });
            }
            return PupilsListVM;
        }());
        Pupils.PupilsListVM = PupilsListVM;
    })(Pupils = SnappetChallenge.Pupils || (SnappetChallenge.Pupils = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=pupilsListVM.js.map
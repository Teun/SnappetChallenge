var SnappetChallenge;
(function (SnappetChallenge) {
    var ApiClient = /** @class */ (function () {
        function ApiClient(httpClient, apiUrlConfig) {
            this.httpClient = httpClient;
            this.apiUrlConfig = apiUrlConfig;
            this.getLearningObjectives = function (dateRangeFilter, callback) {
                return httpClient.get(apiUrlConfig.learningObjectivesUrl, dateRangeFilter, callback);
            };
            this.getUsers = function (dateRangeFilter, callback) {
                return httpClient.get(apiUrlConfig.usersUrl, dateRangeFilter, callback);
            };
            this.getUserDetails = function (userId, dateRangeFilter, callback) {
                return httpClient.get(apiUrlConfig.usersUrl + "/" + userId, dateRangeFilter, callback);
            };
        }
        return ApiClient;
    }());
    SnappetChallenge.ApiClient = ApiClient;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=apiClient.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var ApiUrlConfig = /** @class */ (function () {
        function ApiUrlConfig() {
            this.learningObjectivesUrl = "/api/learningObjective";
            this.usersUrl = "/api/user";
        }
        return ApiUrlConfig;
    }());
    SnappetChallenge.ApiUrlConfig = ApiUrlConfig;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=ApiUrlConfig.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var DateAliasConverter = /** @class */ (function () {
        function DateAliasConverter(dateTimeProvider) {
            this.getDateFromAlias = function (dateAlias) {
                var today = dateTimeProvider.getTodaysDate();
                var date = dateAlias === "today" ? today : new Date(dateAlias);
                return date;
            };
            this.getDateAlias = function (date) {
                if (date.getTime() === dateTimeProvider.getTodaysDate().getTime())
                    return "today";
                else
                    return moment(date).format("YYYY-MM-DD");
            };
        }
        return DateAliasConverter;
    }());
    SnappetChallenge.DateAliasConverter = DateAliasConverter;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateAliasConverter.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var DateRangeFilterBuilder = /** @class */ (function () {
        function DateRangeFilterBuilder() {
            this.getFilterForDate = function (date) {
                var from = SnappetChallenge.Helpers.convertToUtc(date);
                var to = SnappetChallenge.Helpers.convertToUtc(moment(date).add("24", "hours").toDate());
                return {
                    from: moment(from).format("YYYY-MM-DDTHH:mm:ss[Z]"),
                    to: moment(to).format("YYYY-MM-DDTHH:mm:ss[Z]")
                };
            };
        }
        return DateRangeFilterBuilder;
    }());
    SnappetChallenge.DateRangeFilterBuilder = DateRangeFilterBuilder;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateRangeFilterBuilder.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var DateTimeProvider = /** @class */ (function () {
        function DateTimeProvider() {
            var _this = this;
            this.getCurrentUtc = function () {
                return moment("2015-03-24T11:30:00Z").toDate();
            };
            this.getCurrent = function () {
                return moment.utc(_this.getCurrentUtc()).local().toDate();
            };
            this.getTodaysDate = function () {
                return SnappetChallenge.Helpers.truncateTime(_this.getCurrent());
            };
        }
        return DateTimeProvider;
    }());
    SnappetChallenge.DateTimeProvider = DateTimeProvider;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateTimeProvider.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var DialogManager = /** @class */ (function () {
        function DialogManager() {
            this.showMessage = function (message) {
                alert(message);
            };
            this.showConfirmDialog = function (message, confirmCallback) {
                var result = $.Deferred();
                result.done(confirmCallback);
                if (confirm(message)) {
                    result.resolve();
                }
                else {
                    result.reject();
                }
                return result;
            };
        }
        return DialogManager;
    }());
    SnappetChallenge.DialogManager = DialogManager;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dialogManager.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var JQueryHttpClient = /** @class */ (function () {
        function JQueryHttpClient(dialogManager) {
            this.get = function (uri, requestData, callback) {
                var xhr = $.ajax({
                    data: requestData,
                    traditional: true,
                    method: "GET",
                    url: uri,
                    cache: false,
                    timeout: 600000
                });
                if (typeof (callback) === "function")
                    xhr.done(callback);
                xhr.fail(function () { return dialogManager.showMessage("An error occured while requesting new data."); });
                return xhr;
            };
            this.post = function (uri, requestData, callback) {
                var xhr = $.post(uri, requestData, callback);
                xhr.fail(function (message) {
                    dialogManager.showMessage(message);
                });
                return xhr;
            };
        }
        return JQueryHttpClient;
    }());
    SnappetChallenge.JQueryHttpClient = JQueryHttpClient;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=httpClient.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var Services = /** @class */ (function () {
        function Services() {
            this.dialogManager = new SnappetChallenge.DialogManager();
            this.httpClient = new SnappetChallenge.JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new SnappetChallenge.ApiUrlConfig();
            this.apiClient = new SnappetChallenge.ApiClient(this.httpClient, this.apiUriConfig);
            this.dateTimeProvider = new SnappetChallenge.DateTimeProvider();
            this.dateRangeFilterBuilder = new SnappetChallenge.DateRangeFilterBuilder();
            this.dateAliasConverter = new SnappetChallenge.DateAliasConverter(this.dateTimeProvider);
        }
        return Services;
    }());
    SnappetChallenge.Services = Services;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=services.js.map
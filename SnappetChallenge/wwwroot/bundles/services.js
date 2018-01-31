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
    var DateTimeProvider = /** @class */ (function () {
        function DateTimeProvider() {
            var _this = this;
            this.getCurrentUtc = function () {
                return moment("2015-03-24T11:30:00Z").toDate();
            };
            this.getCurrent = function () {
                return moment.utc(_this.getCurrentUtc()).local().toDate();
            };
        }
        return DateTimeProvider;
    }());
    SnappetChallenge.DateTimeProvider = DateTimeProvider;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=dateTimeProvider.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var ApiUriConfig = /** @class */ (function () {
        function ApiUriConfig() {
            this.learningObjectivesUri = "/api/learningObjective";
        }
        return ApiUriConfig;
    }());
    SnappetChallenge.ApiUriConfig = ApiUriConfig;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=apiUriConfig.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var ApiClient = /** @class */ (function () {
        function ApiClient(httpClient, apiUriConfig) {
            this.httpClient = httpClient;
            this.apiUriConfig = apiUriConfig;
            this.getLearningObjectives = function (from, to, callback) {
                return httpClient.get(apiUriConfig.learningObjectivesUri, {
                    from: moment(from).format("YYYY-MM-DDTHH:mm:ss[Z]"),
                    to: moment(to).format("YYYY-MM-DDTHH:mm:ss[Z]")
                }, callback);
            };
        }
        return ApiClient;
    }());
    SnappetChallenge.ApiClient = ApiClient;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=apiClient.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var Services = /** @class */ (function () {
        function Services() {
            this.dialogManager = new SnappetChallenge.DialogManager();
            this.httpClient = new SnappetChallenge.JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new SnappetChallenge.ApiUriConfig();
            this.apiClient = new SnappetChallenge.ApiClient(this.httpClient, this.apiUriConfig);
            this.dateTimeProvider = new SnappetChallenge.DateTimeProvider();
        }
        return Services;
    }());
    SnappetChallenge.Services = Services;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=services.js.map
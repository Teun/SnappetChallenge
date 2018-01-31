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
    var ApiUriConfig = /** @class */ (function () {
        function ApiUriConfig() {
            this.learningObjectivesUri = "/api/learningObjectives";
        }
        return ApiUriConfig;
    }());
    SnappetChallenge.ApiUriConfig = ApiUriConfig;
    var ApiClient = /** @class */ (function () {
        function ApiClient(httpClient, apiUriConfig) {
            this.httpClient = httpClient;
            this.apiUriConfig = apiUriConfig;
            this.getLearningObjectives = function (from, to, callback) {
                return httpClient.get(apiUriConfig.learningObjectivesUri, { from: from, to: to }, callback);
            };
        }
        return ApiClient;
    }());
    SnappetChallenge.ApiClient = ApiClient;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=apiClient.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
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
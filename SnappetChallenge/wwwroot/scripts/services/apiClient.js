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
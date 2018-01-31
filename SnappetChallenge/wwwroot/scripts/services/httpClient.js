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
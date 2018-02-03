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
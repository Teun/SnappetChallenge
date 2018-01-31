var SnappetChallenge;
(function (SnappetChallenge) {
    var FormManager = /** @class */ (function () {
        function FormManager(mainFormHost) {
            this.showMainForm = function (form) {
                mainFormHost.form(form);
            };
        }
        return FormManager;
    }());
    SnappetChallenge.FormManager = FormManager;
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=formManager.js.map
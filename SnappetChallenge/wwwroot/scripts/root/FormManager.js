var SnappetChallenge;
(function (SnappetChallenge) {
    var Root;
    (function (Root) {
        var FormManager = /** @class */ (function () {
            function FormManager(mainFormHost) {
                this.showMainForm = function (form) {
                    mainFormHost.form(form);
                };
            }
            return FormManager;
        }());
        Root.FormManager = FormManager;
    })(Root = SnappetChallenge.Root || (SnappetChallenge.Root = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=formManager.js.map
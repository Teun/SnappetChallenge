var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var LearningObjectivesCatalog = /** @class */ (function () {
            function LearningObjectivesCatalog() {
                this.init = function (services) {
                    var learningObjectivesViewModel = new LearningObjectivesViewModel();
                    var learningObjectivesTemplate = new SnappetChallenge.TemplateForm("learningObjectives", learningObjectivesViewModel);
                    return new SnappetChallenge.CatalogInitResponse("learningObjectives", [
                        new SnappetChallenge.Route("#/learningObjectives", learningObjectivesTemplate)
                    ]);
                };
            }
            return LearningObjectivesCatalog;
        }());
        LearningObjectives.LearningObjectivesCatalog = LearningObjectivesCatalog;
        var LearningObjectivesViewModel = /** @class */ (function () {
            function LearningObjectivesViewModel() {
                this.init = function (params) {
                };
            }
            return LearningObjectivesViewModel;
        }());
        LearningObjectives.LearningObjectivesViewModel = LearningObjectivesViewModel;
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=learningObjectivesCatalog.js.map
var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var LearningObjectivesCatalog = /** @class */ (function () {
            function LearningObjectivesCatalog() {
                this.init = function (services) {
                    var learningObjectivesViewModel = new LearningObjectives.LearningObjectivesListVM(services.dateTimeProvider, services.apiClient);
                    var learningObjectivesTemplate = new SnappetChallenge.TemplateForm("classWork", learningObjectivesViewModel);
                    return new SnappetChallenge.CatalogInitResponse("learningObjectives", "#/class-work/today", "Class work", [
                        new SnappetChallenge.Route("#/class-work/:date", learningObjectivesTemplate)
                    ]);
                };
            }
            return LearningObjectivesCatalog;
        }());
        LearningObjectives.LearningObjectivesCatalog = LearningObjectivesCatalog;
        if (SnappetChallenge.catalogRegistry) {
            SnappetChallenge.catalogRegistry.registerCatalog(new LearningObjectivesCatalog());
        }
        else {
            throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
        }
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=learningObjectivesCatalog.js.map
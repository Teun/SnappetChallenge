var SnappetChallenge;
(function (SnappetChallenge) {
    var LearningObjectives;
    (function (LearningObjectives) {
        var ClassWorkCatalog = /** @class */ (function () {
            function ClassWorkCatalog() {
                this.init = function (services, router) {
                    var learningObjectivesViewModel = new LearningObjectives.ClassWorkVM(services.dateTimeProvider, services.apiClient, services.dateRangeFilterBuilder, services.dateAliasConverter, router);
                    var learningObjectivesTemplate = new SnappetChallenge.TemplateForm("classWork", learningObjectivesViewModel);
                    return new SnappetChallenge.CatalogInitResponse("classWork", "#/class-work/today", "Class work", [
                        new SnappetChallenge.Route("#/class-work/:date", learningObjectivesTemplate)
                    ]);
                };
            }
            return ClassWorkCatalog;
        }());
        LearningObjectives.ClassWorkCatalog = ClassWorkCatalog;
        if (SnappetChallenge.catalogRegistry) {
            SnappetChallenge.catalogRegistry.registerCatalog(new ClassWorkCatalog());
        }
        else {
            throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
        }
    })(LearningObjectives = SnappetChallenge.LearningObjectives || (SnappetChallenge.LearningObjectives = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=classWorkCatalog.js.map
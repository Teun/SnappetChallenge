module SnappetChallenge.LearningObjectives {
    export class ClassWorkCatalog implements ICatalog {
        init: (services: Services, router: SammyInst) => ICatalogInitResponse;

        constructor() {
            this.init = (services: Services, router: SammyInst) => {
                const learningObjectivesViewModel = new LearningObjectives.ClassWorkVM(
                    services.dateTimeProvider,
                    services.apiClient,
                    services.dateRangeFilterBuilder,
                    services.dateAliasConverter,
                    router);
                const learningObjectivesTemplate = new TemplateForm("classWork", learningObjectivesViewModel);
                return new CatalogInitResponse("classWork", "#/class-work/today", "Class work",
                    [
                        new Route("#/class-work/:date", learningObjectivesTemplate)
                    ]);
            }
        }
    }

    if (catalogRegistry) {
        catalogRegistry.registerCatalog(new ClassWorkCatalog());
    } else {
        throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
    }
}
module SnappetChallenge.LearningObjectives {
    export class LearningObjectivesCatalog implements ICatalog {
        init: (services: Services) => ICatalogInitResponse;

        constructor() {
            this.init = (services: Services) => {
                const learningObjectivesViewModel = new LearningObjectivesListVM(services.dateTimeProvider, services.apiClient);
                const learningObjectivesTemplate = new TemplateForm("classWork", learningObjectivesViewModel);
                return new CatalogInitResponse("learningObjectives", "#/class-work/today", "Class work",
                    [
                        new Route("#/class-work/:date", learningObjectivesTemplate)
                    ]);
            }
        }
    }

    if (catalogRegistry) {
        catalogRegistry.registerCatalog(new LearningObjectivesCatalog());
    } else {
        throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
    }
}
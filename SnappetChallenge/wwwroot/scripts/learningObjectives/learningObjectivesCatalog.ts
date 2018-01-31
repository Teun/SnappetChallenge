module SnappetChallenge.LearningObjectives {
    export class LearningObjectivesCatalog implements ICatalog {
        init: (services: Services) => ICatalogInitResponse;

        constructor() {
            this.init = (services: Services) => {
                var learningObjectivesViewModel = new LearningObjectivesViewModel();
                var learningObjectivesTemplate = new TemplateForm("learningObjectives", learningObjectivesViewModel);
                return new CatalogInitResponse("learningObjectives",
                    [
                        new Route("#/learningObjectives", learningObjectivesTemplate)
                    ]);
            }
        }
    }

    export class LearningObjectivesViewModel implements IViewModel {
        init: (params: { date: Date | "today" }) => void;


        constructor() {
            this.init = (params: { date: Date | "today" }) => {
                
            }
        }
    }
}
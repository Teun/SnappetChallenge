module SnappetChallenge.Pupils {
    export class PupilsCatalog implements ICatalog {
        init: (services: Services, router: SammyInst) => ICatalogInitResponse;

        constructor() {
            this.init = (services: Services, router: SammyInst) => {
                const pupilsListViewModel = new PupilsListVM(
                    services.dateTimeProvider,
                    services.dateRangeFilterBuilder,
                    services.dateAliasConverter,
                    services.apiClient,
                    router);
                const pupilsListTemplate = new TemplateForm("pupilsList", pupilsListViewModel);
                const pupilDetailsViewModel = new PupilDetailsVM(
                    services.dateTimeProvider,
                    services.dateRangeFilterBuilder,
                    services.dateAliasConverter,
                    services.apiClient,
                    router);
                const pupilsDetailsTemplate = new TemplateForm("pupilDetails", pupilDetailsViewModel);
                return new CatalogInitResponse("pupils", "#/pupils/today", "Pupils",
                    [
                        new Route("#/pupils/:date", pupilsListTemplate),
                        new Route("#/pupils/:userId/:date", pupilsDetailsTemplate)
                    ]);
            }
        }
    }
    if (catalogRegistry) {
        catalogRegistry.registerCatalog(new PupilsCatalog());
    } else {
        throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
    }
}
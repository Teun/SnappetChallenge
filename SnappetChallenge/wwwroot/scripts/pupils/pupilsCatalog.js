var SnappetChallenge;
(function (SnappetChallenge) {
    var Pupils;
    (function (Pupils) {
        var PupilsCatalog = /** @class */ (function () {
            function PupilsCatalog() {
                this.init = function (services, router) {
                    var pupilsListViewModel = new Pupils.PupilsListVM(services.dateTimeProvider, services.dateRangeFilterBuilder, services.dateAliasConverter, services.apiClient, router);
                    var pupilsListTemplate = new SnappetChallenge.TemplateForm("pupilsList", pupilsListViewModel);
                    var pupilDetailsViewModel = new Pupils.PupilDetailsVM(services.dateTimeProvider, services.dateRangeFilterBuilder, services.dateAliasConverter, services.apiClient, router);
                    var pupilsDetailsTemplate = new SnappetChallenge.TemplateForm("pupilDetails", pupilDetailsViewModel);
                    return new SnappetChallenge.CatalogInitResponse("pupils", "#/pupils/today", "Pupils", [
                        new SnappetChallenge.Route("#/pupils/:date", pupilsListTemplate),
                        new SnappetChallenge.Route("#/pupils/:userId/:date", pupilsDetailsTemplate)
                    ]);
                };
            }
            return PupilsCatalog;
        }());
        Pupils.PupilsCatalog = PupilsCatalog;
        if (SnappetChallenge.catalogRegistry) {
            SnappetChallenge.catalogRegistry.registerCatalog(new PupilsCatalog());
        }
        else {
            throw new Error("CatalogRegistry service must be declared before any self registring catalogs.");
        }
    })(Pupils = SnappetChallenge.Pupils || (SnappetChallenge.Pupils = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=pupilsCatalog.js.map
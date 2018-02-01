module SnappetChallenge {
    export class RootApp {
        formManager: IFormManager;
        services: Services;
        mainViewModel: MainViewModel;

        start: () => void;
        setupRoute: (router: SammyInst, routePattern: string, form: TemplateForm, catalogName: string) => void;

        constructor() {
            this.services = new Services();
            this.mainViewModel = new MainViewModel();
            this.formManager = new FormManager(this.mainViewModel);

            this.start = () => {
                const routerConfig = Sammy("#site-content");
                KoExtensions.init();
                catalogRegistry.getCatalogs()
                    .forEach(c => {
                        const catalogInfo = c.init(this.services, routerConfig);
                        catalogInfo.routes.forEach(r => {
                            this.setupRoute(routerConfig, r.pattern, r.form, catalogInfo.catalogName);
                        });
                        this.mainViewModel.registredCatalogs.push(catalogInfo);
                    });

                ko.applyBindings(this.mainViewModel);
                if (this.mainViewModel.registredCatalogs().length)
                    routerConfig.run(this.mainViewModel.registredCatalogs()[0].defaultRoute);
                $("#site-content").fadeIn(500);
            };

            this.setupRoute = (router: SammyInst, routePattern: string, form: TemplateForm, catalogName: string) => {
                router.get(routePattern, (context) => {
                    this.mainViewModel.form(form);
                    form.data.init(context.params);
                    this.mainViewModel.activeCatalogName(catalogName);
                });
            };
        }
    }

    export interface IFormHost {
        form: KnockoutObservable<TemplateForm>;
    }

    export class MainViewModel implements IFormHost {
        form = ko.observable<TemplateForm>();
        registredCatalogs = ko.observableArray<ICatalogInitResponse>([]);
        activeCatalogName = ko.observable<string>();

        activeCatalog: KnockoutComputed<ICatalogInitResponse>;

        constructor() {
            this.activeCatalog = ko.computed(() => {
                return this.registredCatalogs()
                    .filter(c => c.catalogName === this.activeCatalogName())[0];
            });
        }
    }
}

$(() => {
    new SnappetChallenge.RootApp().start();
});
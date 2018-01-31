module SnappetChallenge {
    export class RootApp {
        formManager: IFormManager;
        services: Services;
        mainViewModel: MainViewModel;
        catalogName = ko.observable<string>();

        start: () => void;
        setupRoute: (router: SammyInst, routePattern: string, catalog: ICatalog) => void;

        constructor() {
            this.services = new Services();
            this.mainViewModel = new MainViewModel();
            this.formManager = new FormManager(this.mainViewModel);

            this.start = () => {
                var routerConfig = Sammy("#site-content");
                //this.setupRoute(routerConfig, "#/learningObjectives");
                ko.applyBindings(this.mainViewModel);

                $("#site-content").fadeIn(500);
            };

            this.setupRoute = (router: SammyInst, routePattern: string, catalog: ICatalog) => {

            };
        }
    }

    export interface IFormHost {
        form: KnockoutObservable<TemplateForm>;
    }

    export class MainViewModel implements IFormHost {
        form = ko.observable<TemplateForm>();
        catalogName = ko.observable<string>();
    }
}
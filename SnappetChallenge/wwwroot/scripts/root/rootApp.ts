module SnappetChallenge.Root {
    export class RootApp {
        formManager: IFormManager;
        services: Services;
        mainViewModel: MainViewModel;
        catalogName = ko.observable<string>();

        start: () => void;
        constructor(subApp: ISubApp) {
            this.services = new Services();
            this.mainViewModel = new MainViewModel();
            this.formManager = new FormManager(this.mainViewModel);

            this.start = () => {
                var response = subApp.init(this);
                this.mainViewModel.catalogName(response.catalogName);
                ko.applyBindings(this.mainViewModel);

                $("#site-content").fadeIn(500);
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

    export class Services {
        apiClient: IApiClient;
        dialogManager: IDialogManager;
        httpClient: IHttpClient;
        apiUriConfig: ApiUriConfig;

        constructor() {
            this.dialogManager = new DialogManager();
            this.httpClient = new JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new ApiUriConfig();
            this.apiClient = new ApiClient(this.httpClient, this.apiUriConfig);
        }
    }
}
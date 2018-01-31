module SnappetChallenge {    
    export class Services {
        apiClient: IApiClient;
        dialogManager: IDialogManager;
        httpClient: IHttpClient;
        dateTimeProvider: IDateTimeProvider;
        apiUriConfig: ApiUriConfig;

        constructor() {
            this.dialogManager = new DialogManager();
            this.httpClient = new JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new ApiUriConfig();
            this.apiClient = new ApiClient(this.httpClient, this.apiUriConfig);
            this.dateTimeProvider = new DateTimeProvider();
        }
    }
}
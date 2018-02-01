module SnappetChallenge {    
    export class Services {
        apiClient: IApiClient;
        dialogManager: IDialogManager;
        httpClient: IHttpClient;
        dateTimeProvider: IDateTimeProvider;
        apiUriConfig: ApiUrlConfig;
        dateRangeFilterBuilder: IDateRangeFilterBuilder;
        dateAliasConverter: IDateAliasConverter;

        constructor() {
            this.dialogManager = new DialogManager();
            this.httpClient = new JQueryHttpClient(this.dialogManager);
            this.apiUriConfig = new ApiUrlConfig();
            this.apiClient = new ApiClient(this.httpClient, this.apiUriConfig);
            this.dateTimeProvider = new DateTimeProvider();
            this.dateRangeFilterBuilder = new DateRangeFilterBuilder();
            this.dateAliasConverter = new DateAliasConverter(this.dateTimeProvider);
        }
    }
}
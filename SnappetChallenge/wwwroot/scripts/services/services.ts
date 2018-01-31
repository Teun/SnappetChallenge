module SnappetChallenge {
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

    export interface IDateTimeProvider {
        getCurrent: () => Date;
        getCurrentUtc: () => Date;
    }

    export class DateTimeProvider implements IDateTimeProvider {
        getCurrent: () => Date;
        getCurrentUtc: () => Date;

        constructor() {
            
        }
    }
}
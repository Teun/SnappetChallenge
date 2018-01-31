module SnappetChallenge {
    import LearningObjective = Models.LearningObjective;

    export interface IHttpClient {
        get: (uri: string, requestData: any, callback: (responseData) => void) => JQueryXHR;
        post: (uri: string, requestData: any, callback: (responseData) => void) => JQueryXHR;
    }

    export class JQueryHttpClient implements IHttpClient {
        get: (uri: string, requestData: any, callback: (responseData) => void) => JQueryXHR;
        post: (uri: string, requestData: any, callback: (responseData) => void) => JQueryXHR;
        constructor(dialogManager: IDialogManager) {
            this.get = (uri: string, requestData: any, callback: (responseData) => void) => {
                var xhr = $.ajax({
                    data: requestData,
                    traditional: true,
                    method: "GET",
                    url: uri,
                    cache: false,
                    timeout: 600000
                });
                if (typeof (callback) === "function")
                    xhr.done(callback);
                xhr.fail(() => dialogManager.showMessage("An error occured while requesting new data."));
                return xhr;
            };
            this.post = (uri: string, requestData: any, callback: (responseData) => void) => {
                var xhr = $.post(uri, requestData, callback);
                xhr.fail((message) => {
                    dialogManager.showMessage(message);
                });
                return xhr;
            };
        }
    }

    export interface IDialogManager {
        showMessage: (message: string) => void;
        showConfirmDialog: (message: string, confirmCallback: () => void) => JQueryPromise<any>;
    }

    export class DialogManager implements IDialogManager {
        showMessage: (message: string) => void;
        showConfirmDialog: (message: string, confirmCallback: () => void) => JQueryPromise<any>;

        constructor() {
            this.showMessage = (message: string) => {
                alert(message);
            };

            this.showConfirmDialog = (message: string, confirmCallback: () => void) => {
                var result = $.Deferred();
                result.done(confirmCallback);
                if (confirm(message)) {
                    result.resolve();
                } else {
                    result.reject();
                }
                return result;
            }
        }
    }

    export class ApiUriConfig {
        learningObjectivesUri = "/api/learningObjectives";
    }

    export interface IApiClient {
        getLearningObjectives: (from: Date, to: Date, callback: (data: LearningObjective[]) => void) => JQueryXHR;
    }

    export class ApiClient implements IApiClient {
        getLearningObjectives: (from: Date, to: Date, callback: (data: LearningObjective[]) => void) => JQueryXHR;

        constructor(private httpClient: IHttpClient, private apiUriConfig: ApiUriConfig) {
            this.getLearningObjectives = (from: Date, to: Date, callback: (data: LearningObjective[]) => void) => {
                return httpClient.get(apiUriConfig.learningObjectivesUri, { from: from, to: to }, callback);
            }
        }
    }
}
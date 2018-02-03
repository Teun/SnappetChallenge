module SnappetChallenge {
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
}
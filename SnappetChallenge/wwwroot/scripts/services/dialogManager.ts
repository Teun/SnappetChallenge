module SnappetChallenge {
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
}
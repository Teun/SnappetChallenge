module SnappetChallenge.Root {
    export interface IFormManager {
        showMainForm: (form: TemplateForm) => void;
    }

    export class FormManager implements IFormManager {
        showMainForm: (form: TemplateForm) => void;
        constructor(mainFormHost: IFormHost) {

            this.showMainForm = (form: TemplateForm) => {
                mainFormHost.form(form);
            };
        }
    }
}
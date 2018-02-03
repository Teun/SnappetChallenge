module SnappetChallenge {
    export interface IViewModel {
        init: (params: any) => void;
    }

    export class Route {
        constructor(public pattern: string, public form: TemplateForm) {
        }
    }

    export class TemplateForm {
        constructor(public name: string, public data: IViewModel) {
        }
    }
}
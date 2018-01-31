module SnappetChallenge.Root {
    export interface ISubApp {
        init: (root: RootApp) => ISubAppInitResponse;
    }

    export interface ISubAppInitResponse {
        catalogName: string
    }

    export class SubAppInitResponse implements ISubAppInitResponse {
        constructor(public catalogName: string) {
        }
    }

    export class EmptyApp implements ISubApp {
        init: (root: RootApp) => ISubAppInitResponse;
        constructor(public catalogName: string) {
            this.init = (root: RootApp) => {
                return this;
            };
        }
    }
}
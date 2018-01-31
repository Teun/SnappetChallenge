module SnappetChallenge {
    export interface ICatalogInitResponse {
        catalogName: string;
        defaultRoute: string;
        title: string;
        routes: Route[];
    }

    export class CatalogInitResponse implements ICatalogInitResponse {
        constructor(public catalogName: string, public defaultRoute: string, public title: string, public routes: Route[]) {
        }
    }
}
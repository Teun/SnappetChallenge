module SnappetChallenge {
    export interface ICatalog {
        init: (services: Services) => ICatalogInitResponse;
    }

    export interface ICatalogInitResponse {
        catalogName: string;
        routes: Route[];
    }

    export class CatalogInitResponse implements ICatalogInitResponse {
        constructor(public catalogName: string, public routes: Route[]) {
        }
    }
}
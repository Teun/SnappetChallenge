module SnappetChallenge {
    export interface ICatalog {
        init: (services: Services) => ICatalogInitResponse;
    }
}


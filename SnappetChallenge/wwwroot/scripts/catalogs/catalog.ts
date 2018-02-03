module SnappetChallenge {
    export interface ICatalog {
        init: (services: Services, router: SammyInst) => ICatalogInitResponse;
    }
}


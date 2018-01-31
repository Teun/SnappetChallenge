module SnappetChallenge {
    export class CatalogRegistry {
        private catalogs: ICatalog[] = [];
        registerCatalog: (catalog: ICatalog) => void;
        getCatalogs: () => ICatalog[];

        constructor() {
            this.registerCatalog = (catalog: ICatalog) => {
                this.catalogs.push(catalog);
            };

            this.getCatalogs = () => {
                return this.catalogs;
            };
        }
    }

    export const catalogRegistry = new CatalogRegistry();
}
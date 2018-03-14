
function makeAppConfig() {
    const AppConfig: LayoutAppConfig = {
        navbarOpened: true,
        isScreenFull: false
    };

    return AppConfig;
}
export class LayoutAppConfig {
    navbarOpened: boolean;
    isScreenFull: boolean;
}

export const APPCONFIG = makeAppConfig();

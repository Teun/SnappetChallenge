import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAppConfig } from './interfaces/iapp-config';

@Injectable()

export class AppConfig {
    static settings: IAppConfig;
    constructor(private http: HttpClient) { }
    load() {
        console.log("Start loading............");
        const jsonFile = `../assets/config/config.json`;
        return new Promise<void>((resolve, reject) => {
            this.http.get(jsonFile).toPromise().then((response: IAppConfig) => {
                AppConfig.settings = <IAppConfig>response;
                console.log(AppConfig.settings);
                resolve();
            }).catch((response: any) => {
                reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
            });
        });
    }
}

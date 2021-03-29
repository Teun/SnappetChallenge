import { environment } from '../../environments/environment';
// import {Injectable} from '@angular/core';

// @Injectable()
export class ApiHelper {

    static get(service: string = '', postfix: string = ''): string {
        const api = environment.api;
        // @ts-ignore
        const apiService = api.services[service];
        return (service !== '' && typeof apiService !== 'undefined')
            ? this.root() + apiService + (postfix ? '/' + postfix : '')
            : '';
    }

    static root(): string {
        return environment.api.base;
    }

}

import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { environment } from '../environments/environment';

import { AuthService } from './auth/auth.service';
import { AuthHttp } from 'angular2-jwt';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import { Injectable } from '@angular/core';

@Injectable()
export class Api {

    private baseUrl = '/api/';

    private http: AuthHttp;

    constructor(private authService: AuthService) {
        this.http = this.authService.http();
    }

    auth(param: any = null): Observable<Nicollas.Dto.Identity.tokenDto> {
        return this.authService.auth(param)
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    }

    get<T>(path: string, body: any = null): Observable<T> {
        const fullPath = this.baseUrl + path + this.bodyToQueryString(body);

        return this.http.get(fullPath, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    }

    post<T>(path: string, param: any = null): Observable<T> {
        const body = JSON.stringify(param);
        const fullPath = this.baseUrl + path;

        return this.http.post(fullPath, body, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    }

    delete<T>(path: string, body: any = null): Observable<T> {
        const fullPath = this.baseUrl + path + this.bodyToQueryString(body);

        return this.http.delete(fullPath, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    }

    put<T>(path: string, param: any = null): Observable<T> {
        const body = JSON.stringify(param);
        const fullPath = this.baseUrl + path;

        return this.http.put(fullPath, body, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    }

    postFile<T>(path: string, param: any = null, files: File[]): Observable<T> {
        const fullPath = this.baseUrl + path;
        const formData: FormData = new FormData();
        if (files && files.length === 1) {
            formData.append('files', files[0], files[0].name);
        } else if (files) {
            // For multiple files
            for (let i = 0; i < files.length; i++) {
                formData.append(`files[]`, files[i], files[i].name);
            }
        }
        if (param !== '' && param !== undefined && param !== null) {
            for (const property in param) {
                if (param.hasOwnProperty(property)) {
                    if (typeof param[property] === 'number') {
                        formData.append(property, param[property].toString().replace(/[.,]/g, ','))
                    } else {
                        formData.append(property, param[property]);
                    }
                }
            }
        }
        return this.http.post(fullPath, formData)
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    }



    private getOptions(): RequestOptions {
        const options = new RequestOptions(
            { headers: new Headers({ 'Content-Type': 'application/json' }) });
        return this.authService.insertRealtimeToken(options);
        // return this.authService.addTokenHeaderIfAuth(options);
    }

    private bodyToQueryString(obj: any) {
        const parts: any = [];
        for (const key in obj) {
            if (obj.hasOwnProperty(key)) {
                parts.push(encodeURIComponent(key) + '=' + encodeURIComponent(obj[key]));
            }
        }

        return parts ? '?' + parts.join('&') : '';
    }

    private checkForError(response: Response): Response | Observable<any> {
        if (response.status >= 200 && response.status < 300) {
            return response;
        }

        const error = new Error(response.statusText);
        error['response'] = response;
        console.error(error);
        throw error;
    }

    private handleError(error: Response) {
        console.log(error);
        if (error.status === 401) {
            // location.reload();
        }

        if (!environment.production) {
            alert(error);
            console.error(error);
        }

        return Observable.throw(error || 'Server error');
    }

    private getJson(response: Response) {
        try {
            return response.json();
        } catch (ex) {
            return response.text();
        }
    }
}

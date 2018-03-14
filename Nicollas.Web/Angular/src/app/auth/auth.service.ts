import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { AuthHttp, JwtHelper } from 'angular2-jwt';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class AuthService {
    private jwtUrl  = '/token';

    constructor(private authHttp: AuthHttp) { }

    http(): AuthHttp {
        return this.authHttp;
    }

    auth(param: any = null): Observable<Response> {
        const options = new RequestOptions({ headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' }) } );

        return this.authHttp.post(this.jwtUrl, param, options);
    }

    getToken(): Nicollas.Dto.Identity.tokenDto {
        return JSON.parse(localStorage.getItem('token'));
    }

    saveToken(token: Nicollas.Dto.Identity.tokenDto) {
        localStorage.setItem('token', JSON.stringify(token));
    }

    removeToken() {
        localStorage.removeItem('token');
    }

    isAuthenticate(): boolean {
        const jwtHelper: JwtHelper = new JwtHelper();
        const objToken = this.getToken();
        if (!objToken) {
            return false;
        }
        const token = objToken.access_token;
        try {
            if (token == null || jwtHelper.isTokenExpired(token)) {
                this.removeToken();
                return false;
            }

            jwtHelper.decodeToken(token);
        } catch (e) {
            this.removeToken();
            return false;
        }

        return true;
    }

    insertRealtimeToken(options: RequestOptions): RequestOptions {
        const token = localStorage.getItem('realtimeToken');
        if (token) {
            options.headers.append('Realtime-Token', token);
        }
        return options;
    }

    saveRealtimeToken(token: string): void {
        localStorage.setItem('realtimeToken', token);
    }

    removeRealtimeTOken(): void {
        localStorage.removeItem('realtimeToken');
    }



    // addTokenHeaderIfAuth(options: RequestOptions ): RequestOptions {
    //     if (this.isAuthenticate()) {
    //         const token = this.getToken();
    //         options.headers.append('Authorization',  `Bearer ${token.access_token}`);
    //     }

    //     return options;
    // }
}

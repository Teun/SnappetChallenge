import { Injectable } from '@angular/core';
import { Api } from 'app/api.service';
import { AuthService } from 'app/auth/auth.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SignService {

    constructor(private api: Api, public auth: AuthService) { }

    SignIn(username: string, password: string): Observable<Nicollas.Dto.Identity.tokenDto> {
        const result = this.api
            .auth(`username=${username}&password=${password}`)
            .do((res) => {
                this.auth.saveToken(res);
                return res;
            });

        return result;
    }

    Logout(): Observable<boolean> {
        return this.api.post<boolean>('Sign/Logout');
    }

    ResetPassword(userId: string, token: string, password: string): Observable<boolean> {
        return this.api.get<boolean>('Sign/ResetPassword', { userId: userId, token: token, newPassword: password });
    }

    RequestResetPassword(user: Nicollas.Dto.Identity.userDto): Observable<Nicollas.Dto.Identity.userDto> {
        return this.api.post<Nicollas.Dto.Identity.userDto>('Sign/RequestResetPassword', user);
    }

    SignUp(user: Nicollas.Dto.Identity.userDto): Observable<boolean> {
        const password = user.password;
        const result = this.api.post<any>('Sign/Singup' + `/?password=${password}`, user).map(
            r => {
                return true;
            }
        ).catch(err => { return Observable.throw(err || 'Server error'); });
        return result;
    }

    ResendEmail(username: string): Observable<any> {
        return this.api.get<any>('Sign/resendConfirmationEmail', { username: username });
    }

    GetEmailRestriction(): Observable<string[]> {
        return this.api.get<string[]>('Sign/GetEmailDomainRestriction');
    }

    DefaultPassword(userId: string, password: string): Observable<boolean> {
        return this.api.get<boolean>('Sign/DefaultPassword', { id: userId, password: password }).publishLast().refCount();
    }

}

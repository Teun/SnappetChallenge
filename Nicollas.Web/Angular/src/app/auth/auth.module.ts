import { NgModule } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { AuthHttp, AuthConfig } from 'angular2-jwt';
import { AuthService } from './auth.service';

export function authHttpServiceFactory(http: Http, options: RequestOptions) {
  return new AuthHttp(new AuthConfig(
    {
      noJwtError: true,
      tokenName: 'token',
      tokenGetter: (() => {  const token = JSON.parse(localStorage.getItem('token')); return token ? token.access_token : ''; }),
    }),
    http, options);
}

@NgModule({
  providers: [
    AuthService,
    {
      provide: AuthHttp,
      useFactory: authHttpServiceFactory,
      deps: [Http, RequestOptions]
    }
  ]
})
export class AuthModule { }

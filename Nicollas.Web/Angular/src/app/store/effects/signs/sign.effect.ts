import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/skip';
import 'rxjs/add/operator/takeUntil';
import { Injectable } from '@angular/core';
import { Effect, Actions, toPayload } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { empty } from 'rxjs/observable/empty';
import { of } from 'rxjs/observable/of';

import { SignService } from 'app/services/signs/sign.service';
import * as action from '../../actions/signs/sign.action';
import { Filter } from 'app/store/reducers/BaseReducer';

import { defer } from 'rxjs/observable/defer';


/**
 * Effects offer a way to isolate and easily test side-effects within your
 * application.
 * The `toPayload` helper function returns just
 * the payload of the currently dispatched action, useful in
 * instances where the current state is not necessary.
 *
 * Documentation on `toPayload` can be found here:
 * https://github.com/ngrx/effects/blob/master/docs/api.md#topayload
 *
 * If you are unfamiliar with the operators being used in these examples, please
 * check out the sources below:
 *
 * Official Docs: http://reactivex.io/rxjs/manual/overview.html#categories-of-operators
 * RxJS 5 Operators By Example: https://gist.github.com/btroncone/d6cf141d6f2c00dc6b35
 */
@Injectable()
export class SignEffects {
    /**
   * This effect makes use of the `startWith` operator to trigger
   * the effect immediately on startup.
   */
  @Effect()
  LoadTokenData$: Observable<Action> = defer(() => {
      if (this.service.auth.isAuthenticate()){
        return of(new action.LogInCompleteAction(this.service.auth.getToken()))
      }
      return of(new action.FailAction(null));
    });


  @Effect()
  Login$: Observable<Action> = this.actions$
    .ofType(action.LOG_IN_REQUEST) // the action type that will hit this
    .map((action: action.LogInRequestAction) => action.payload)
    .switchMap(entity => {

      const next$ = this.actions$.ofType(action.LOG_IN_REQUEST).skip(1);

      return this.service.SignIn(entity.userName, entity.password)
        .takeUntil(next$)
        .map(result => new action.LogInCompleteAction(result))
        .catch((err) => of(new action.FailAction(err)));
    });

  @Effect()
  Logout$: Observable<Action> = this.actions$
    .ofType(action.LOGOUT_REQUEST) // the action type that will hit this
    .map((_: action.LogoutRequestAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.LOGOUT_REQUEST).skip(1);

      return this.service.Logout()
        .takeUntil(next$)
        .map(_ => {
          this.service.auth.removeToken();
          location.reload();
          return new action.LogoutCompleteAction()
        })
        .catch((err) => of(new action.FailAction(err)));
    });

  @Effect()
  Signup$: Observable<Action> = this.actions$
    .ofType(action.SIGNUP) // the action type that will hit this
    .map((action: action.SignupAction) => action.payload)
    .switchMap(entity => {

      const next$ = this.actions$.ofType(action.SIGNUP).skip(1);

      return this.service.SignUp(entity)
        .takeUntil(next$)
        .map(result => new action.SignupCompleteAction(result))
        .catch((err) => of(new action.FailAction(err.text())));
    });


  @Effect()
  ResendEmail$: Observable<Action> = this.actions$
    .ofType(action.EMAIL) // the action type that will hit this
    .map((action: action.ResendEmailAction) => action.payload)
    .switchMap(username => {

      const next$ = this.actions$.ofType(action.EMAIL).skip(1);

      return this.service.ResendEmail(username)
        .takeUntil(next$)
        .map(result => new action.ResendEmailCompleteAction(result))
        .catch((err) => of(new action.FailAction(err.text())));
    });

  @Effect()
  SendToken$: Observable<Action> = this.actions$
    .ofType(action.TOKEN) // the action type that will hit this
    .map((action: action.TokenAction) => action.payload)
    .switchMap(entity => {

      const next$ = this.actions$.ofType(action.TOKEN).skip(1);

      return this.service.ResetPassword(entity.id, entity.token, entity.password)
        .takeUntil(next$)
        .map(result => new action.TokenCompleteAction(result))
        .catch((err) => of(new action.FailAction(err.text())));
    });

  @Effect()
  DefaultPassword$: Observable<Action> = this.actions$
    .ofType(action.DEFAULT_PASSWORD) // the action type that will hit this
    .map((action: action.DefaultPasswordAction) => action.payload)
    .switchMap(data => {

      const next$ = this.actions$.ofType(action.DEFAULT_PASSWORD).skip(1);

      return this.service.DefaultPassword(data.id, data.password)
        .takeUntil(next$)
        .map(result => new action.DefaultPasswordCompleteAction())
        .catch((err) => of(new action.FailAction(err.text())));
    });

  @Effect()
  RecoveryAccount$: Observable<Action> = this.actions$
    .ofType(action.ACCOUNT) // the action type that will hit this
    .map((action: action.AccountRecoveryAction) => action.payload)
    .switchMap(username => {

      const next$ = this.actions$.ofType(action.EMAIL).skip(1);

      return this.service.RequestResetPassword(username).takeUntil(next$)
        .map(result => new action.AccountRecoveryCompleteAction())
        .catch((err) => of(new action.FailAction(err.text())));
    });

  @Effect()
  Domains$: Observable<Action> = this.actions$
    .ofType(action.DOMAIN) // the action type that will hit this
    .map((action: action.DomainAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.DOMAIN).skip(1);

      return this.service.GetEmailRestriction()
        .takeUntil(next$)
        .map(result => new action.DomainCompleteAction(result))
        .catch((err) => of(new action.FailAction(err.text())));
    });

  constructor(private actions$: Actions, private service: SignService) { }
}

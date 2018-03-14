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

import * as action from 'app/store/actions/identity/role.action';
import { Filter } from 'app/store/reducers/BaseReducer';
import { RoleService } from 'app/services/identity/role.service';


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
export class RoleEffects {

  @Effect()
  load$: Observable<Action> = this.actions$
    .ofType(action.READ) // the action type that will hit this
    .map((action: action.ReadAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.READ).skip(1);

      return this.service.Read()
        .takeUntil(next$)
        .map(result => new action.ReadCompleteAction(new Filter <Nicollas.Dto.Identity.roleDto, string> (result)))
        .catch((err) => of(new action.FaliedAction(err)));
    });

  @Effect()
  Create$: Observable<Action> = this.actions$
    .ofType(action.CREATE) // the action type that will hit this
    .map((action: action.CreateAction) => action.payload)
    .switchMap(entity => {
      const next$ = this.actions$.ofType(action.CREATE).skip(1);

      return this.service.Create(entity)
        .takeUntil(next$)
        .map(result => new action.CreateCompleteAction((Object.assign({}, entity, {id: result}))))
        .catch((err) => of(new action.FaliedAction(err)));
    });

  @Effect()
  Update$: Observable<Action> = this.actions$
    .ofType(action.UPDATE) // the action type that will hit this
    .map((action: action.UpdateAction) => action.payload)
    .switchMap(entity => {
      const next$ = this.actions$.ofType(action.UPDATE).skip(1);

      return this.service.Update(entity)
        .takeUntil(next$)
        .map(result => new action.UpdateCompleteAction((entity)))
        .catch((err) => of(new action.FaliedAction(err)));
    });


  @Effect()
  Disable$: Observable<Action> = this.actions$
    .ofType(action.DISABLE) // the action type that will hit this
    .map((action: action.DisableAction) => action.payload)
    .switchMap(entity => {
      const next$ = this.actions$.ofType(action.DISABLE).skip(1);

      return this.service.DisableOrEnable(entity)
        .takeUntil(next$)
        .map(result => new action.UpdateCompleteAction((Object.assign({}, entity, {disabled: !entity.disabled}))))
        .catch((err) => of(new action.FaliedAction(err)));
    });

  constructor(private actions$: Actions, private service: RoleService) { }
}

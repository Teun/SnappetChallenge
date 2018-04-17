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

import * as action from 'app/store/actions/reports/report.action';
import { Filter } from 'app/store/reducers/BaseReducer';
import { ReportService } from 'app/services/reports/report.service';
import { SendJsonAction } from 'app/store/actions/reports/report.action';


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
export class ReportEffects {
  @Effect()
  SendJson$: Observable<Action> = this.actions$
    .ofType(action.SEND_JSON) // the action type that will hit this
    .map((action: action.SendJsonAction) => action.payload)
    .switchMap(jsonString => {

      const next$ = this.actions$.ofType(action.SEND_JSON).skip(1);

      return this.service.SendJsonString(jsonString)
        .takeUntil(next$)
        .map(result => new action.SendJsonActionComplete())
        .catch((err) => of(new action.FaliedAction(err)));
    });


  @Effect()
  loadAplyMonth$: Observable<Action> = this.actions$
    .ofType(action.LOAD_APLY_MONTH) // the action type that will hit this
    .map((action: action.LoadAplyMonthAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.LOAD_APLY_MONTH).skip(1);

      return this.service.ReadApplyMonth()
        .takeUntil(next$)
        .map(result => new action.LoadAplyMonthCompleteAction(result))
        .catch((err) => of(new action.FaliedAction(err)));
    });

  @Effect()
  loadAplyWeek$: Observable<Action> = this.actions$
    .ofType(action.LOAD_APLY_WEEK) // the action type that will hit this
    .map((action: action.LoadAplyWeekAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.LOAD_APLY_WEEK).skip(1);

      return this.service.ReadApplyWeek()
        .takeUntil(next$)
        .map(result => new action.LoadAplyWeekCompleteAction(result))
        .catch((err) => of(new action.FaliedAction(err)));
    });


  @Effect()
  loadDificultyWeek$: Observable<Action> = this.actions$
    .ofType(action.LOAD_DIFICULTY_WEEK) // the action type that will hit this
    .map((action: action.LoadDificultyWeekAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.LOAD_DIFICULTY_WEEK).skip(1);

      return this.service.ReadDificultyWeek()
        .takeUntil(next$)
        .map(result => new action.LoadDificultyWeekCompleteAction(result))
        .catch((err) => of(new action.FaliedAction(err)));
    });


  @Effect()
  loadProgressWeek$: Observable<Action> = this.actions$
    .ofType(action.LOAD_PROGRESS_WEEK) // the action type that will hit this
    .map((action: action.LoadProgressWeekAction) => null)
    .switchMap(_ => {

      const next$ = this.actions$.ofType(action.LOAD_PROGRESS_WEEK).skip(1);

      return this.service.ReadProgressWeek()
        .takeUntil(next$)
        .map(result => new action.LoadProgressWeekCompleteAction(result))
        .catch((err) => of(new action.FaliedAction(err)));
    });

  @Effect()
  loadProgressByStudantWeek$: Observable<Action> = this.actions$
    .ofType(action.LOAD_PROGRESS_STUDANT_WEEK) // the action type that will hit this
    .map((action: action.LoadProgressByStudantWWeekAction) => action.payload)
    .switchMap(studantId => {

      const next$ = this.actions$.ofType(action.LOAD_PROGRESS_STUDANT_WEEK).skip(1);

      return this.service.ReadProgressByStudantWeek(studantId)
        .takeUntil(next$)
        .map(result => new action.LoadProgressByStudantWWeekCompleteAction(result))
        .catch((err) => of(new action.FaliedAction(err)));
    });

  @Effect()
  loadDificultByStudantWeek$: Observable<Action> = this.actions$
    .ofType(action.LOAD_DIFICULTY_STUDANT_WEEK) // the action type that will hit this
    .map((action: action.LoadDificultyByStudantWeekAction) => action.payload)
    .switchMap(studantId => {

      const next$ = this.actions$.ofType(action.LOAD_DIFICULTY_STUDANT_WEEK).skip(1);

      return this.service.ReadDificultyByStudantWeek(studantId)
        .takeUntil(next$)
        .map(result => new action.LoadDificultyByStudantWWeekCompleteAction(result))
        .catch((err) => of(new action.FaliedAction(err)));
    });



  constructor(private actions$: Actions, private service: ReportService) { }
}

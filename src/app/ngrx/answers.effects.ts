import {Injectable} from '@angular/core';
import {Actions, createEffect, ofType} from '@ngrx/effects';
import {of} from 'rxjs';
import {catchError, map, mergeMap, tap, withLatestFrom} from 'rxjs/operators';
import {AnswersService} from "../services/answers.service";
import {
  changeControlState,
  loadAnswers,
  loadAnswerSuccess,
  loadUsers,
  loadUsersSuccess, refreshControlState,
  serverUnavailable
} from "./answers.actions";
import {UserService} from "../services/user.service";
import {ControlsState} from "../interfaces/controls-state";
import {Socket} from "ngx-socket-io";
import {Store} from "@ngrx/store";
import {State} from "../interfaces/state";
import {selectControlState} from "./answers.reducer";

@Injectable()
export class AnswersEffects {
  loadAnswers$ = createEffect(() => this.actions$.pipe(
    ofType(loadAnswers.type),
    mergeMap(() => this.answersService.getAnswers()
      .pipe(
        map(answer => loadAnswerSuccess(answer)),
        catchError(() => of(serverUnavailable()))
      ))
    )
  );

  loadUsers$ = createEffect(() => this.actions$.pipe(
    ofType(loadUsers.type),
    mergeMap(() => this.userService.getUsers()
      .pipe(
        map(users => loadUsersSuccess({ users })),
        catchError(() => of(serverUnavailable()))
      ))
    )
  );

  loadAnswersAfterUsers$ = createEffect(() => this.actions$.pipe(
    ofType(loadUsersSuccess.type),
    map(() => loadAnswers()),
  ));

  toggleSocket$ = createEffect(() => this.actions$.pipe(
    ofType(changeControlState.type),
    tap((payload: { controlState: ControlsState }) => {
      if (payload.controlState === ControlsState.Stop) {
        this.socket.disconnect();
      } else {
        this.socket.connect();
      }
    })
  ), { dispatch: false });

  refreshControlState$ = createEffect(() => this.actions$.pipe(
    ofType(refreshControlState.type),
    mergeMap(() => {
      return this.store.select(selectControlState).pipe(
        map(controlState => changeControlState({ controlState }))
      );
    }),
  ));

  constructor(
    private actions$: Actions,
    private answersService: AnswersService,
    private userService: UserService,
    private socket: Socket,
    private store: Store<State>,
  ) {}
}

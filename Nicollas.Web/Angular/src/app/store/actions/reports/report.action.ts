import { Action } from '@ngrx/store';
import { Filter } from 'app/store/reducers/BaseReducer';

export const LOAD_APLY_MONTH = '[Reports] LOAD_APLY_MONTH';
export const LOAD_APLY_MONTH_COMPLETE = '[Reports] LOAD_APLY_MONTH_COMPLETE';

export const LOAD_APLY_WEEK = '[Reports] LOAD_APLY_WEEK';
export const LOAD_APLY_WEEK_COMPLETE = '[Reports] LOAD_APLY_WEEK_COMPLETE';

export const LOAD_DIFICULTY_WEEK = '[Reports] LOAD_DIFICULTY_WEEK';
export const LOAD_DIFICULTY_WEEK_COMPLETE = '[Reports] LOAD_DIFICULTY_WEEK_COMPLETE';

export const LOAD_PROGRESS_WEEK = '[Reports] LOAD_PROGRESS_WEEK';
export const LOAD_PROGRESS_WEEK_COMPLETE = '[Reports] LOAD_PROGRESS_WEEK_COMPLETE';

export const SEND_JSON = '[Reports] SEND_JSON';
export const SEND_JSON_COMPLETE = '[Reports] SEND_JSON_COMPLETE';



export const ACTION_FAILED = '[Reports] ACTION_FAILED';

export class SendJsonAction implements Action {
  readonly type = SEND_JSON;
  constructor(public payload: string) { }
}
export class SendJsonActionComplete implements Action {
  readonly type = SEND_JSON_COMPLETE;
  constructor() { }
}

export class LoadAplyMonthAction implements Action {
  readonly type = LOAD_APLY_MONTH;
  constructor() { }
}
export class LoadAplyMonthCompleteAction implements Action {
  readonly type = LOAD_APLY_MONTH_COMPLETE;
  constructor(public payload: Ngx.Charts.Single[]) { }
}


export class LoadAplyWeekAction implements Action {
  readonly type = LOAD_APLY_WEEK;
  constructor() { }
}
export class LoadAplyWeekCompleteAction implements Action {
  readonly type = LOAD_APLY_WEEK_COMPLETE;
  constructor(public payload: Ngx.Charts.Multiple[]) { }
}

export class LoadDificultyWeekAction implements Action {
  readonly type = LOAD_DIFICULTY_WEEK;
  constructor() { }
}
export class LoadDificultyWeekCompleteAction implements Action {
  readonly type = LOAD_DIFICULTY_WEEK_COMPLETE;
  constructor(public payload: Ngx.Charts.Multiple[]) { }
}

export class LoadProgressWeekAction implements Action {
  readonly type = LOAD_PROGRESS_WEEK;
  constructor() { }
}
export class LoadProgressWeekCompleteAction implements Action {
  readonly type = LOAD_PROGRESS_WEEK_COMPLETE;
  constructor(public payload: Ngx.Charts.Multiple[]) { }
}

export class FaliedAction implements Action {
  readonly type = ACTION_FAILED;
  constructor(public payload: Response) { }
}



/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type Actions = FaliedAction
  | LoadAplyMonthAction | LoadAplyMonthCompleteAction
  | LoadAplyWeekAction | LoadAplyWeekCompleteAction
  | LoadDificultyWeekAction | LoadDificultyWeekCompleteAction
  | LoadProgressWeekAction | LoadProgressWeekCompleteAction
  | SendJsonAction | SendJsonActionComplete

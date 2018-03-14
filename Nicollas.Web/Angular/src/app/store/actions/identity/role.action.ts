import { Action } from '@ngrx/store';
import { Filter } from 'app/store/reducers/BaseReducer';

export const CREATE = '[Role] Create';
export const CREATE_COMPLETE = '[Role] CreateComplete';

export const READ = '[Role] Read';
export const READ_COMPLETE = '[Role] ReadComplete';

export const UPDATE = '[Role] Update';
export const UPDATE_COMPLETE = '[Role] UpdateComplete';

export const DELETE = '[Role] Delete';
export const DELETE_COMPLETE = '[Role] DeleteComplete';

export const DISABLE = '[Role] Disable';
export const DISABLE_COMPLETE = '[Role] DisableComplete';

export const ACTION_FAILED = '[Role] ActionFailed';


export class CreateAction implements Action {
  readonly type = CREATE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}
export class CreateCompleteAction implements Action {
  readonly type = CREATE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}


export class ReadAction implements Action {
  readonly type = READ;
  constructor() { }
}
export class ReadCompleteAction implements Action {
  readonly type = READ_COMPLETE;
  constructor(public payload: Filter<Nicollas.Dto.Identity.roleDto, string>) { }
}

export class UpdateAction implements Action {
  readonly type = UPDATE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}
export class UpdateCompleteAction implements Action {
  readonly type = UPDATE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}


export class DeleteAction implements Action {
  readonly type = DELETE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}
export class DeleteCompleteAction implements Action {
  readonly type = DELETE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}


export class DisableAction implements Action {
  readonly type = DISABLE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
}
export class DisableCompleteAction implements Action {
  readonly type = DISABLE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.roleDto) { }
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
  | CreateAction | CreateCompleteAction
  | ReadAction | ReadCompleteAction
  | UpdateAction | UpdateCompleteAction
  | DeleteAction | DeleteCompleteAction;

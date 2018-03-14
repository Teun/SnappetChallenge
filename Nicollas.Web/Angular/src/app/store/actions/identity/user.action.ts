import { Action } from '@ngrx/store';
import { Filter } from 'app/store/reducers/BaseReducer';

export const CREATE = '[User] Create';
export const CREATE_COMPLETE = '[User] CreateComplete';

export const READ = '[User] Read';
export const READ_COMPLETE = '[User] ReadComplete';

export const UPDATE = '[User] Update';
export const UPDATE_COMPLETE = '[User] UpdateComplete';

export const DELETE = '[User] Delete';
export const DELETE_COMPLETE = '[User] DeleteComplete';

export const DISABLE = '[User] Disable';
export const DISABLE_COMPLETE = '[User] DisableComplete';

export const RESET_PASSWORD = '[User] ResetPassword';
export const CHANGE_PASSWORD = '[User] ChangePassword';
export const PASSWORD_COMPLETE = '[User] PasswordCompleted';

export const ACTION_FAILED = '[User] ActionFailed';


export class CreateAction implements Action {
  readonly type = CREATE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class CreateCompleteAction implements Action {
  readonly type = CREATE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}


export class ResetPasswordAction implements Action {
  readonly type = RESET_PASSWORD;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class ChangePasswordAction implements Action {
  readonly type = CHANGE_PASSWORD;
  constructor(public payload: { entity: Nicollas.Dto.Identity.userDto, current: string, newPassword: string}) { }
}
export class PasswordCompleteAction implements Action {
  readonly type = PASSWORD_COMPLETE;
  constructor() { }
}





export class ReadAction implements Action {
  readonly type = READ;
  constructor() { }
}
export class ReadCompleteAction implements Action {
  readonly type = READ_COMPLETE;
  constructor(public payload: Filter<Nicollas.Dto.Identity.userDto, string>) { }
}

export class UpdateAction implements Action {
  readonly type = UPDATE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class UpdateCompleteAction implements Action {
  readonly type = UPDATE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}


export class DeleteAction implements Action {
  readonly type = DELETE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class DeleteCompleteAction implements Action {
  readonly type = DELETE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}


export class DisableAction implements Action {
  readonly type = DISABLE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class DisableCompleteAction implements Action {
  readonly type = DISABLE_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
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
  | DeleteAction | DeleteCompleteAction
  | ResetPasswordAction | ChangePasswordAction | PasswordCompleteAction;

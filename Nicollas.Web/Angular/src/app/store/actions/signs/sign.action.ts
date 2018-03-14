import { Action } from '@ngrx/store';

import { Filter } from 'app/store/reducers/BaseReducer';

export const FAILED = '[Sign] Failed';

export const LOG_IN_REQUEST = '[Sign] LogInRequest';
export const LOG_IN_COMPLETE = '[Sign] LogInComplete';

export const LOGOUT_REQUEST = '[Sign] LogoutRequest';
export const LOGOUT_COMPLETE = '[Sign] LogoutComplete';

export const SIGNUP = '[Sign] SignupRequest';
export const SIGNUP_COMPLETE = '[Sign] SignupComplete';

export const DOMAIN = '[Sign] Domain';
export const DOMAIN_COMPLETE = '[Sign] DomainComplete';

export const EMAIL = '[Sign] Email';
export const EMAIL_COMPLETE = '[Sign] EmailComplete';


export const ACCOUNT = '[Sign] RecoveryAccount';
export const ACCOUNT_COMPLETE = '[Sign] RecoveryAccountComplete';

export const DEFAULT_PASSWORD = '[Sign] DefaultPassword';
export const DEFAULT_PASSWORD_COMPLETE = '[Sign] DefaultPasswordComplete';


export const TOKEN = '[Sign] Token';
export const TOKEN_COMPLETE = '[Sign] TokenComplete';

/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 *
 * See Discriminated Unions: https://www.typescriptlang.org/docs/handbook/advanced-types.html#discriminated-unions
 */
export class DefaultPasswordAction implements Action {
  readonly type = DEFAULT_PASSWORD;
  constructor(public payload: { id: string, password: string }) { }
}
export class DefaultPasswordCompleteAction implements Action {
  readonly type = DEFAULT_PASSWORD_COMPLETE;
  constructor() { }
}

export class LogInRequestAction implements Action {
  readonly type = LOG_IN_REQUEST;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class LogInCompleteAction implements Action {
  readonly type = LOG_IN_COMPLETE;
  constructor(public payload: Nicollas.Dto.Identity.tokenDto) { }
}
export class LogoutRequestAction implements Action {
  readonly type = LOGOUT_REQUEST;
  constructor() { }
}
export class LogoutCompleteAction implements Action {
  readonly type = LOGOUT_COMPLETE;
  constructor() { }
}
export class FailAction implements Action {
  readonly type = FAILED;
  constructor(public payload: any) { }
}

export class SignupAction implements Action {
  readonly type = SIGNUP;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class SignupCompleteAction implements Action {
  readonly type = SIGNUP_COMPLETE;
  constructor(public payload: boolean) { }
}


export class DomainAction implements Action {
  readonly type = DOMAIN;
  constructor() { }
}
export class DomainCompleteAction implements Action {
  readonly type = DOMAIN_COMPLETE;
  constructor(public payload: string[]) { }
}


export class ResendEmailAction implements Action {
  readonly type = EMAIL;
  constructor(public payload: string) { }
}
export class ResendEmailCompleteAction implements Action {
  readonly type = EMAIL_COMPLETE;
  constructor(public payload: boolean) { }
}

export class AccountRecoveryAction implements Action {
  readonly type = ACCOUNT;
  constructor(public payload: Nicollas.Dto.Identity.userDto) { }
}
export class AccountRecoveryCompleteAction implements Action {
  readonly type = ACCOUNT_COMPLETE;
  constructor() { }
}


export class TokenAction implements Action {
  readonly type = TOKEN;
  constructor(public payload: { id: string, token: string, password: string }) { }
}
export class TokenCompleteAction implements Action {
  readonly type = TOKEN_COMPLETE;
  constructor(public payload: boolean) { }
}

/**
 * Export a type alias of all actions in this action group
 * so that reducers can easily compose action types
 */
export type Actions = FailAction
  | LogInRequestAction | LogInCompleteAction
  | LogoutRequestAction | LogoutCompleteAction
  | SignupAction | SignupCompleteAction
  | DomainAction | DomainCompleteAction
  | ResendEmailAction | ResendEmailCompleteAction
  | TokenAction | TokenCompleteAction
  | AccountRecoveryAction | AccountRecoveryCompleteAction
  | DefaultPasswordAction | DefaultPasswordCompleteAction;

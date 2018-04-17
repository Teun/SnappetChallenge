import * as typeActions from '../../actions/signs/sign.action';
import * as base from 'app/store/reducers/BaseReducer';

/**
 * The state interface that the reducer recive
 */
export interface State {
    busy: boolean;
    authenticated: boolean;
    signupRequested: boolean;
    emailResent: boolean;
    tokenActived: boolean;
    tokenResponse: Nicollas.Dto.Identity.tokenDto;
    error: any
    domains: string[];
    lastActionOnReducer: string
};

/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
export const initialState: State = {
    busy: false,
    authenticated: false,
    signupRequested: false,
    emailResent: false,
    tokenActived: false,
    tokenResponse: null,
    error: null,
    domains: [],
    lastActionOnReducer: null
};

/**
 * @example The concept of reducer is:
 * Recive an object (state) and an action(with type of the action and the parameter.
 * with the action, the reducer function create an new state based on the state received, modify
 * this new state and return it.
 * this way, the reducer is an Pure function and never can modify the received state.
 * @param state the object to be based a new one
 * @param action the action to create the new state Object
 */
export function reducer(state: State = initialState, action: typeActions.Actions): State {
    switch (action.type) {
        case typeActions.LOGOUT_COMPLETE: {
            return Object.assign({}, initialState, { lastActionOnReducer: action.type });
        }
        case typeActions.LOG_IN_COMPLETE: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, authenticated: true, tokenResponse: action.payload
            });
        }
        case typeActions.SIGNUP_COMPLETE: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: null, signupRequested: true
            });
        }
        case typeActions.EMAIL_COMPLETE: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: null, emailResent: true
            })
        }
        case typeActions.DOMAIN_COMPLETE: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: null, domains: action.payload
            })
        }
        case typeActions.ACCOUNT_COMPLETE: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false
            })
        }

        case typeActions.FAILED: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: action.payload
            })
        }

        case typeActions.DEFAULT_PASSWORD_COMPLETE:
        case typeActions.TOKEN_COMPLETE: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false
            })
        }

        case typeActions.DEFAULT_PASSWORD:
        case typeActions.ACCOUNT:
        case typeActions.TOKEN:
        case typeActions.EMAIL:
        case typeActions.DOMAIN:
        case typeActions.SIGNUP:
        case typeActions.LOG_IN_REQUEST: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    busy: true,
                    authenticated: false,
                    signupRequested: false,
                    emailResent: false,
                    tokenActived: false
                });
        }
        default: {
            return state;
        }
    }
}


import * as typeActions from 'app/store/actions/identity/user.action';
import * as base from 'app/store/reducers/BaseReducer';

/**
 * The state interface that the reducer recive
 */
export interface State {
    loading: boolean;
    container: base.Filter<Nicollas.Dto.Identity.userDto, string>[];
    error: Response;
    lastActionOnReducer: string
};

/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
export const initialState: State = {
    loading: false,
    container: [],
    error: null,
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
        case typeActions.CREATE_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: false,
                    container: base.PureInsertOrUpdate(state.container, state.container[0].insert(action.payload))
                });
        }
        case typeActions.DELETE_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: false,
                    container: base.PureInsertOrUpdate(state.container, state.container[0].remove(action.payload))
                });
        }
        case typeActions.UPDATE_COMPLETE: {
            return Object.assign({}, state, {
                    lastActionOnReducer: action.type,
                loading: false,
                container: base.PureReplaceEntity(state.container, action.payload)
            });
        }
        case typeActions.READ_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: false,
                    container: base.PureInsertOrUpdate(state.container, action.payload)
                });
        }
        case typeActions.PASSWORD_COMPLETE: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: false });
        }
        case typeActions.RESET_PASSWORD:
        case typeActions.CREATE:
        case typeActions.READ:
        case typeActions.UPDATE:
        case typeActions.DELETE: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: true, error: null });
        }
        case typeActions.ACTION_FAILED: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: false, error: action.payload });
        }

        default: {
            return state;
        }
    }
}
export const get = (state: State) => { return state.container.length !== 0 ? state.container[0].values : [] ; }

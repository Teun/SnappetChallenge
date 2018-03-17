import * as typeActions from 'app/store/actions/reports/report.action';
import * as base from 'app/store/reducers/BaseReducer';

/**
 * The state interface that the reducer recive
 */
export interface State {
    loading: number;
    aplyMonth: Ngx.Charts.Single[];
    aplyWeek: Ngx.Charts.Multiple[];
    dificultyWeek: Ngx.Charts.Multiple[];
    progressWeek: Ngx.Charts.Multiple[];
    error: Response;
    lastActionOnReducer: string
};

/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
export const initialState: State = {
    loading: 0,
    aplyMonth: [],
    aplyWeek: [],
    dificultyWeek: [],
    progressWeek: [],
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
        case typeActions.LOAD_APLY_MONTH_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: state.loading - 1,
                    aplyMonth: action.payload
                });
        }
        case typeActions.LOAD_APLY_WEEK_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: state.loading - 1,
                    aplyWeek: action.payload
                });
        }
        case typeActions.LOAD_DIFICULTY_WEEK_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: state.loading - 1,
                    dificultyWeek: action.payload
                });
        }
        case typeActions.LOAD_PROGRESS_WEEK_COMPLETE: {
            return Object.assign({}, state,
                {
                    lastActionOnReducer: action.type,
                    loading: state.loading - 1,
                    progressWeek: action.payload
                });
        }
        case typeActions.LOAD_DIFICULTY_WEEK:
        case typeActions.LOAD_PROGRESS_WEEK:
        case typeActions.LOAD_APLY_WEEK:
        case typeActions.LOAD_APLY_MONTH: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: state.loading + 1, error: null });
        }
        case typeActions.ACTION_FAILED: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: state.loading - 1, error: action.payload });
        }

        default: {
            return state;
        }
    }
}
export const getAplyMonth = (state: State) => { return state.aplyMonth; }
export const getAplyWeek = (state: State) => { return state.aplyWeek; }
export const getDificultyWeek = (state: State) => { return state.dificultyWeek; }
export const getProgressWeek = (state: State) => { return state.progressWeek; }

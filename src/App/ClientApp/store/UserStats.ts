import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface UserStatsState {
	isLoading: boolean;
	startDateIndex: number;
	stats: UserStats[];
	periodStart: string;
	periodEnd: string;
	errorLoading: boolean;
}

export interface UserStatsCollection {
	periodStart: string;
	periodEnd: string;
	stats: UserStats[];
}

export interface UserStats {
	id: number;
	userName: string;
	exercisesAttempted: number;
	exercisesSolvedOnFirstTry: number;
	exercisesSolved: number;
	avgTriesPerExercise: number;
	correctFirstTryRate: number;
	avgProgressPerExercise: number;
	totalProgress: number;
	latestProgressCusum: number[];
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestUserStatsAction {
	type: 'REQUEST_USER_STATS',
	startDateIndex: number;
}

interface ErrorUserStatsAction {
	type: 'ERROR_USER_STATS',
	startDateIndex: number;
}

interface ReceiveUserStatsAction {
	type: 'RECEIVE_USER_STATS',
	startDateIndex: number;
	data: UserStatsCollection
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestUserStatsAction
	| ReceiveUserStatsAction
	| ErrorUserStatsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
	requestUserStats: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
		// Only load data if it's something we don't already have (and are not already loading)
		if (startDateIndex !== getState().userStats.startDateIndex) {
			let status = 0;
			const fetchTask =  fetch(`/api/stats?startDateIndex=${ startDateIndex }`)
				.then(response => {
					status = response.status;
					return response.json() as Promise<UserStatsCollection>
				})
				.then(data => {
					if (status > 300) {
						throw new Error(JSON.stringify(data));
					}
					dispatch({ type: 'RECEIVE_USER_STATS', startDateIndex: startDateIndex, data });
				})
				.catch(data => {
					console.log(data);
					dispatch({ type: 'ERROR_USER_STATS', startDateIndex: startDateIndex });
				});

			addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
			dispatch({ type: 'REQUEST_USER_STATS', startDateIndex: startDateIndex });
		}
	}
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: UserStatsState = {
	startDateIndex: null,
	stats: [],
	periodStart: null,
	periodEnd: null,
	isLoading: false,
	errorLoading: false
};

export const reducer: Reducer<UserStatsState> = (state: UserStatsState, action: KnownAction) => {
	switch (action.type) {
		case 'REQUEST_USER_STATS':
			return Object.assign({}, state, {
				startDateIndex: action.startDateIndex,
				isLoading: true,
				errorLoading: false
			});
		case 'RECEIVE_USER_STATS':
			// Only accept the incoming data if it matches the most recent request. This ensures we correctly
			// handle out-of-order responses.
			if (action.startDateIndex === state.startDateIndex) {
				return {
					startDateIndex: action.startDateIndex,
					stats: action.data.stats,
					periodStart: action.data.periodStart,
					periodEnd: action.data.periodEnd,
					isLoading: false,
					errorLoading: false
				};
			}
			break;
		case 'ERROR_USER_STATS':
			if (action.startDateIndex === state.startDateIndex) {
				return {
					startDateIndex: action.startDateIndex,
					stats: [],
					periodStart: null,
					periodEnd: null,
					isLoading: false,
					errorLoading: true
				};
			}
			break;
		default:
			// The following line guarantees that every action in the KnownAction union has been covered by a case above
			const exhaustiveCheck: never = action;
	}

	return state || unloadedState;
};

import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface LearningObjectivesState {
    isLoading: boolean;
    dateIndex?: number;
    date?: Date;
    objectives: LearningObjective[];
    domains: ChartData<string, number>[];
}

export interface LearningObjectiveModel {
    date: Date;
    objectives: LearningObjective[];
    domains: ChartData<string, number>[]
}

export interface LearningObjective {
    title: string;
    domain: string;
    totalStudents: number;
    totalSubmittedAnswers: number;
    totalProgress: number;
    averageDifficulty: number;
}

export interface ChartData<TX, TY> {
    xAxis: TX;
    yAxis: TY;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestLearningObjectivesAction {
    type: 'REQUEST_LEARNING_OBJECTIVES';
    dateIndex: number;
}

interface ReceiveLearningObjectivesAction {
    type: 'RECEIVE_LEARNING_OBJECTIVES';
    dateIndex: number;
    date: Date;
    objectives: LearningObjective[];
    domains: ChartData<string, number>[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestLearningObjectivesAction | ReceiveLearningObjectivesAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestLearningObjectives: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (startDateIndex !== getState().learningObjectives.dateIndex) {
            let fetchTask = fetch(`api/WorkData/LearningObjectives?dateIndex=${startDateIndex}`)
                .then(response => response.json() as Promise<LearningObjectiveModel>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_LEARNING_OBJECTIVES', dateIndex: startDateIndex, objectives: data.objectives, date: data.date, domains: data.domains });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_LEARNING_OBJECTIVES', dateIndex: startDateIndex });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: LearningObjectivesState = { objectives: [], domains: [], isLoading: false };

export const reducer: Reducer<LearningObjectivesState> = (state: LearningObjectivesState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_LEARNING_OBJECTIVES':
            return {
                dateIndex: action.dateIndex,
                objectives: state.objectives,
                domains: state.domains,
                isLoading: true
            };
        case 'RECEIVE_LEARNING_OBJECTIVES':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.dateIndex === state.dateIndex) {
                return {
                    dateIndex: action.dateIndex,
                    objectives: action.objectives,
                    date: action.date,
                    domains: action.domains,
                    isLoading: false
                };
            }
            break;
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};

import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';


export interface StudentsState {
    isLoading: boolean;
    dateIndex?: number;
    date?: Date;
    learningObjective?: string;
    students: Student[];
}

export interface StudentModel {
    date: Date;
    students: Student[];
    learningObjective: string;
}

export interface Student {
    id: number;
    subject: string;
    correctAttempts: number;
    inCorrectAttempts: number;
    uniqueExercises: number;
    submittedAnswers: number;
    currentProgress: number;
    averageDifficulty: number;
}

// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestStudentsAction {
    type: 'REQUEST_STUDENTS';
    dateIndex: number;
    learningObjective: string;
}

interface ReceiveStudentsAction {
    type: 'RECEIVE_STUDENTS';
    dateIndex: number;
    date: Date;
    students: Student[];
    learningObjective: string;
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestStudentsAction | ReceiveStudentsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestStudents: (startDateIndex: number, learningObjective: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (startDateIndex !== getState().students.dateIndex || learningObjective !== getState().students.learningObjective) {
            let fetchTask = fetch(`api/WorkData/StudentsProgress?dateIndex=${startDateIndex}&learningObjective=${learningObjective}`)
                .then(response => response.json() as Promise<StudentModel>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_STUDENTS', dateIndex: startDateIndex, students: data.students, date: data.date, learningObjective: data.learningObjective });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_STUDENTS', dateIndex: startDateIndex, learningObjective: learningObjective });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: StudentsState = { students: [], isLoading: false };

export const reducer: Reducer<StudentsState> = (state: StudentsState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_STUDENTS':
            return {
                dateIndex: action.dateIndex,
                learningObjective: action.learningObjective,
                students: state.students,
                isLoading: true
            };
        case 'RECEIVE_STUDENTS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.dateIndex === state.dateIndex && action.learningObjective === state.learningObjective) {
                return {
                    dateIndex: action.dateIndex,
                    students: action.students,
                    date: action.date,
                    learningObjective: action.learningObjective,
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

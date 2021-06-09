import {Action, createReducer, createSelector, on} from '@ngrx/store';
import {
  changeControlState,
  changeLearningObjective,
  loadAnswerSuccess,
  loadUsersSuccess,
  serverUnavailable
} from "./answers.actions";
import {allLearningObjectives, Answer, LearningObjective, UserId} from "../models/answer";
import {ControlsState} from "../interfaces/controls-state";
import {TableRow} from "../interfaces/table-row";
import {User} from "../models/user";
import {State} from "../interfaces/state";

export interface AnswersState {
  answers: Answer[],
  serverUnavailable: boolean,
  learningObjective: LearningObjective,
  learningObjectives: LearningObjective[],
  controlState: ControlsState,
  tableRows: TableRow[],
  users: User[],
  stats: {
    [objective: string]: {
      users: UserId[],
      answers: number,
    },
  }
}

const initialStats = {
  [allLearningObjectives]: {
    users: [],
    answers: 0,
  },
};

export const initialState: AnswersState = {
  answers: [],
  serverUnavailable: false,
  learningObjective: allLearningObjectives,
  learningObjectives: [],
  controlState: ControlsState.Play,
  tableRows: [],
  users: [],
  stats: {
    [allLearningObjectives]: {
      users: [],
      answers: 0,
    },
  },
};

const _answersReducer = createReducer(
  initialState,
  on(loadAnswerSuccess, (state, action) => {
    if (state.controlState === ControlsState.Pause) {
      return state;
    }

    const tableRows = (() => {
      const user = state.users.find(user => user.id === action.UserId);
      const userName = user && user.name || action.UserId;
      const student = state.tableRows.find(row => row.userId === action.UserId);

      if (student == null) {
        return [...state.tableRows, {
          userId: action.UserId,
          userName: String(userName),
          answers: [{
            correct: action.Correct,
            learningObjective: action.LearningObjective,
          }],
        }];
      }

      return state.tableRows.map(row => {
        if (row.userId !== student.userId) {
          return row;
        } else {
          return {
            ...row,
            answers: [
              ...row.answers,
              {
                correct: action.Correct,
                learningObjective: action.LearningObjective,
              }
            ]
          }
        }
      });
    })();

    const learningObjectives = (
      state.learningObjectives.includes(action.LearningObjective)
      ? state.learningObjectives
      : [...state.learningObjectives, action.LearningObjective]
    );

    const stats = (() => {
      const allLearningObjectivesStats = {
        users: [...state.stats[allLearningObjectives].users],
        answers: state.stats[allLearningObjectives].answers,
      }
      const objective = action.LearningObjective;

      if (!allLearningObjectivesStats.users.includes(action.UserId)) {
        allLearningObjectivesStats.users.push(action.UserId);
      }

      allLearningObjectivesStats.answers++;

      const objectiveStats: { users: UserId[], answers: number } = objective in state.stats ?
        {
          users: state.stats[objective].users.includes(action.UserId)
            ? state.stats[objective].users
            : [...state.stats[objective].users, action.UserId],
          answers: state.stats[objective].answers + 1,
        } :
        {
          users: [action.UserId],
          answers: 1,
        };

      return {
        ...state.stats,
        [allLearningObjectives]: allLearningObjectivesStats,
        [objective]: objectiveStats,
      };
    })();

    return {
      ...state,
      answers: [...state.answers, action],
      learningObjectives,
      tableRows,
      stats,
    };
  }),
  on(loadUsersSuccess, (state, action) => {
    return {
      ...state,
      users: action.users,
    };
  }),
  on(serverUnavailable, (state) => {
    return {
      ...state,
      serverUnavailable: true,
    };
  }),
  on(changeLearningObjective, (state, action) => {
    return {
      ...state,
      learningObjective: action.learningObjective,
    };
  }),
  on(changeControlState, (state, action) => {
    return {
      ...state,
      controlState: action.controlState,
    };
  }),
  on(changeControlState, (state, action) => {
    if (action.controlState !== ControlsState.Stop) {
      return state;
    }

    return {
      ...state,
      stats: initialStats,
      tableRows: [],
    };
  }),
);

export function answersReducer(state: AnswersState | undefined, action: Action) {
  return _answersReducer(state, action);
}

export const selectVisibleRows = createSelector(
  (state: State) => state.answers.tableRows,
  (state: State) => state.answers.learningObjective,
  (tableRows, learningObjective) => {
    return tableRows.map(row => {
      return {
        ...row,
        answers: row.answers.filter(answer => {
          return (
            answer.learningObjective === learningObjective ||
            learningObjective === allLearningObjectives
          );
        })
      }
    });
  }
);

export const selectTotalStudents = createSelector(
  (state: State) => state.answers.stats,
  (state: State) => state.answers.learningObjective,
  (statistics, learningObjective) => {
    if (statistics[learningObjective] == null) {
      return 0;
    }
    return statistics[learningObjective].users.length || 0;
  }
);

export const selectTotalAnswers = createSelector(
  (state: State) => state.answers.stats,
  (state: State) => state.answers.learningObjective,
  (statistics, learningObjective) => {
    if (statistics[learningObjective] == null) {
      return 0;
    }
    return statistics[learningObjective].answers || 0;
  }
)

export const selectControlState = createSelector(
  (state: State) => state.answers.controlState,
  controlState => controlState,
);

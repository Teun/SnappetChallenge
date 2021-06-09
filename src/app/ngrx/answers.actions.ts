import {createAction, props} from '@ngrx/store';
import {Answer, LearningObjective} from "../models/answer";
import {User} from "../models/user";
import {ControlsState} from "../interfaces/controls-state";

export const loadAnswers = createAction('[Answers Page] Load Answers');
export const loadAnswerSuccess = createAction('[Answers API] Answer Loaded', props<Answer>());
export const loadUsers = createAction('[Answers Page] Load Users');
export const loadUsersSuccess = createAction('[Users API] Users Loaded', props<{ users: User[] }>());
export const serverUnavailable = createAction('Server Unavailable');
export const changeLearningObjective = createAction('Change Learning Objective', props<{ learningObjective: LearningObjective }>());
export const changeControlState = createAction('Change Control State', props<{ controlState: ControlsState }>());

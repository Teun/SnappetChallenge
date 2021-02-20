
import reduceReducers from 'reduce-reducers';
import {combineReducers} from 'redux';
import {connectRouter} from 'connected-react-router';

import UIReducer from './ui';
import ExerciseResultsReducer from './exercises-results';

const createRootReducer = history => reduceReducers(
  UIReducer,
  ExerciseResultsReducer,
  combineReducers({
    router: connectRouter(history),
    root: (state = {}, _) => state,
  })
);

export default createRootReducer;

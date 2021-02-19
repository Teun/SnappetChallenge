
import reduceReducers from 'reduce-reducers';
import {combineReducers} from 'redux';
import {connectRouter} from 'connected-react-router';

import UIReducer from './ui';

const createRootReducer = history => reduceReducers(
  UIReducer,
  combineReducers({
    router: connectRouter(history),
    root: (state = {}, _) => state,
  })
);

export default createRootReducer;

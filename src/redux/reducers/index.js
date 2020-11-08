import reduceReducers from 'reduce-reducers';
import {combineReducers} from 'redux';

import dataReducer from './data';

const createRootReducer = () => reduceReducers(
  dataReducer,
  combineReducers({
    root: (state = {}, _) => state,
  }),
);

export default createRootReducer;

import {createStore} from 'redux';
import createRootReducer from '../reducers';

const reducer = createRootReducer();

const store = createStore(
  reducer,
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

export default store;

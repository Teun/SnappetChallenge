import {createStore, applyMiddleware, compose} from 'redux';
import {routerMiddleware} from 'connected-react-router';

import history from '../history';
import createRootReducer from '../redux/reducers';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const appRouterMiddleware = routerMiddleware(history);
const reducer = createRootReducer(history);

const configureStore = () => {
  const store = createStore(
    reducer,
    composeEnhancers(
      applyMiddleware(appRouterMiddleware),
    )
  );

  return store;
};

export default configureStore();

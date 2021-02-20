import {createStore, applyMiddleware, compose} from 'redux';
import createSagaMiddleware from 'redux-saga';
import {routerMiddleware} from 'connected-react-router';

import sagas from '../sagas';
import history from '../history';
import createRootReducer from '../redux/reducers';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const appRouterMiddleware = routerMiddleware(history);
const reducer = createRootReducer(history);
const sagaMiddleware = createSagaMiddleware();

const configureStore = () => {
  const store = createStore(
    reducer,
    composeEnhancers(
      applyMiddleware(sagaMiddleware, appRouterMiddleware),
    )
  );

  sagaMiddleware.run(sagas);

  return store;
};

export default configureStore();

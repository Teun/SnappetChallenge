import {handleActions as handle} from 'redux-actions';
import {lens, identity, compose, map} from 'ramda';

export const defaultTo = value => lens(a => (a === undefined ? value : a), identity);

export const handleActions = compose(
  actions => handle(actions, {}),
  map(action => (state, {payload}) => action(payload)(state)),
);

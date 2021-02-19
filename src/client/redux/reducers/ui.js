import {compose, lensPath, over, append, add, flip, subtract, lensProp, drop} from 'ramda';
import {v4 as uuid} from 'uuid';

import {handleActions, defaultTo} from '../../utils/state';

import {setIsLoading, unsetIsLoading, showSnackbar, hideSnackbar} from '../actions/ui';

export const uiLens = lensProp('UI');

export const isLoadingState = compose(
  uiLens,
  lensPath(['isLoading']),
  defaultTo(0)
);

export const snackbarState = compose(
  uiLens,
  lensPath(['snackbar']),
  defaultTo([])
);

export default handleActions({
  [setIsLoading]: () => over(isLoadingState, add(1)),
  [unsetIsLoading]: () => over(isLoadingState, flip(subtract)(1)),
  [showSnackbar]: ({text, severity}) => over(
    snackbarState,
    append({text, severity, id: uuid()})
  ),
  [hideSnackbar]: () => over(snackbarState, drop(1)),
});

import {compose, over, append, add, flip, subtract, lensProp, drop, set, always} from 'ramda';
import {v4 as uuid} from 'uuid';

import {handleActions, defaultTo} from '../../utils/state';
import {rootLens} from './_lenses';

import {
  setIsLoading, unsetIsLoading,
  showSnackbar, hideSnackbar,
  showDrawer, hideDrawer
} from '../actions/ui';

export const uiLens = compose(rootLens, lensProp('UI'));

export const isLoadingState = compose(
  uiLens,
  lensProp('isLoading'),
  defaultTo(0)
);

export const snackbarState = compose(
  uiLens,
  lensProp('snackbar'),
  defaultTo([])
);

export const drawerIsOpenState = compose(
  uiLens,
  lensProp('drawerIsOpen'),
  defaultTo(false)
);

const hideDrawerHandler = always(set(drawerIsOpenState, false));

export default handleActions({
  [setIsLoading]: () => over(isLoadingState, add(1)),
  [unsetIsLoading]: () => over(isLoadingState, flip(subtract)(1)),
  [showSnackbar]: ({text, severity}) => over(
    snackbarState,
    append({text, severity, id: uuid()})
  ),
  [hideSnackbar]: () => over(snackbarState, drop(1)),
  [showDrawer]: always(set(drawerIsOpenState, true)),
  [hideDrawer]: hideDrawerHandler,
  '@@router/LOCATION_CHANGE': hideDrawerHandler,
});

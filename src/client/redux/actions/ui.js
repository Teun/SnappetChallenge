import {createAction} from 'redux-actions';

export const showSnackbar = createAction('SHOW_SNACKBAR');
export const hideSnackbar = createAction('HIDE_SNACKBAR');

export const showDrawer = createAction('SHOW_DRAWER');
export const hideDrawer = createAction('HIDE_DRAWER');

export const setIsLoading = createAction('SET_IS_LOADING');
export const unsetIsLoading = createAction('UNSET_IS_LOADING');

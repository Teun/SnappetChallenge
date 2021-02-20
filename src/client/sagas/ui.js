import {put, delay, takeEvery} from 'redux-saga/effects';

import {showSnackbar, hideSnackbar} from '../redux/actions/ui';

export const hideSnackbarAfterDelaySaga = function*() {
  yield delay(3000);
  yield put(hideSnackbar());
};

export default [
  takeEvery(showSnackbar().type, hideSnackbarAfterDelaySaga),
];

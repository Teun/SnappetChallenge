import {put, call, takeEvery} from 'redux-saga/effects';

import {getExercisesResults, setExercisesResults} from '../redux/actions/exercises-results';
import {setIsLoading, unsetIsLoading, showSnackbar} from '../redux/actions/ui';
import service from '../services/exercises-results';
import {SnackbarType} from '../constants';

export const getExercisesResultsSaga = function*({payload}) {
  try {
    yield put(setIsLoading());
    const {from, to} = payload;
    const response = yield call(service.getAll, {from, to});
    yield put(setExercisesResults(response.data.results));
  } catch (error) {
    yield put(showSnackbar({text: error.message, severity: SnackbarType.error}));
  } finally {
    yield put(unsetIsLoading());
  }
};

export default [
  takeEvery(getExercisesResults().type, getExercisesResultsSaga),
];

import {all} from 'redux-saga/effects';

import UISaga from './ui';
import ExercisesResultsSaga from './exercises-results';

export default function* rootSaga() {
  yield all([
    ...UISaga,
    ...ExercisesResultsSaga,
  ]);
}

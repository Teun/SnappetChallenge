import {compose, lensProp, set} from 'ramda';

import {handleActions, defaultTo} from '../../utils/state';
import {rootLens} from './_lenses';

import {setExercisesResults, setDateFrom, setDateTo} from '../actions/exercises-results';

export const exerciseResultsLens = compose(rootLens, lensProp('exercises'));

export const exerciseResultsState = compose(
  exerciseResultsLens,
  lensProp('exercisesResults'),
  defaultTo([])
);

export const dateFromState = compose(
  exerciseResultsLens,
  lensProp('dateFrom'),
  defaultTo('2015-03-24T00:00:00Z')
);

export const dateToState = compose(
  exerciseResultsLens,
  lensProp('dateTo'),
  defaultTo('2015-03-24T11:30:00Z')
);

export default handleActions({
  [setExercisesResults]: set(exerciseResultsState),
  [setDateFrom]: set(dateFromState),
  [setDateTo]: set(dateToState),
});

import {view} from 'ramda';

import reducer, {exerciseResultsState, dateFromState, dateToState} from '../exercises-results';
import {setExercisesResults, setDateFrom, setDateTo} from '../../actions/exercises-results';

describe('reducers', () => {
  describe('ui', () => {
    describe('exerciseResultsState', () => {
      test('should set the exercises results in the state', () => {
        const items = [1, 2, 3, 4, 5];

        const newStore = reducer({}, setExercisesResults(items));
        const result = view(exerciseResultsState, newStore);

        expect(result).toIncludeSameMembers(items);
      });

      test('should set the dateFrom in the state', () => {
        const date = new Date().toString();

        const newStore = reducer({}, setDateFrom(date));
        const result = view(dateFromState, newStore);

        expect(result).toBe(date);
      });

      test('should set the dateTo in the state', () => {
        const date = new Date().toString();

        const newStore = reducer({}, setDateTo(date));
        const result = view(dateToState, newStore);

        expect(result).toBe(date);
      });
    });
  });
});

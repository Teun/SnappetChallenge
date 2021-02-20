import {call, put} from 'redux-saga/effects';
import sagaHelper from 'redux-saga-testing';

import {getExercisesResults, setExercisesResults} from '../../redux/actions/exercises-results';
import {setIsLoading} from '../../redux/actions/ui';
import service from '../../services/exercises-results';
import {getExercisesResultsSaga} from '../exercises-results';

describe('sagas', () => {
  describe('exercises-results', () => {

    describe('getExercisesResults successfully reach the api', () => {
      const from = '2015-03-30T00:00:00.000Z';
      const to = '2015-03-30T23:59:59.000Z';
      const action = getExercisesResults({from, to});
      const it = sagaHelper(getExercisesResultsSaga(action));
      it('should set isLoading ', result => {
        expect(result).toEqual(put(setIsLoading()));
      });

      it('should call the api', result => {
        expect(result).toEqual(call(service.getAll, action.payload));
        return {data:  {results: [1, 2, 3]}};
      });

      it('should call setExercisesResults to save the results in the store ', result => {
        expect(result).toEqual(put(setExercisesResults([1, 2, 3])));
      });
    });
  });
});

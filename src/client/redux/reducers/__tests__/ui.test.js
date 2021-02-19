import {set, view} from 'ramda';

import reducer, {isLoadingState, snackbarState} from '../ui';
import {setIsLoading, unsetIsLoading, showSnackbar, hideSnackbar} from '../../actions/ui';

import {SnackbarType} from '../../../constants';

describe('reducers', () => {
  describe('ui', () => {
    describe('isLoadingState', () => {
      test('should add 1 call to the isLoadingState', () => {
        const store = set(isLoadingState, 0, {});

        const newStore = reducer(store, setIsLoading());
        const result = view(isLoadingState, newStore);

        expect(result).toBe(1);
      });

      test('should remove 1 call from isLoadingState', () => {
        const store = set(isLoadingState, 4, {});

        const newStore = reducer(store, unsetIsLoading());
        const result = view(isLoadingState, newStore);

        expect(result).toBe(3);
      });
    });

    describe('showSnackbar', () => {
      test('should add a new snackbar state stack', () => {
        const store = set(snackbarState, [], {});

        const message = {
          text: 'info text', severity: SnackbarType.error
        };

        const newStore = reducer(store, showSnackbar(message));
        const result = view(snackbarState, newStore);

        expect(result).toIncludeAllMembers([{id: 'randomId', ...message}]);
      });
    });

    describe('hideSnackbar', () => {
      test('should remove the oldest alarm in the snackbar state stack', () => {
        const store = set(snackbarState, [
          {id: 'randomId', text: 'info text', severity: SnackbarType.info},
          {id: 'randomId', severity: SnackbarType.error, text: 'Error text'},
          {id: 'randomId', text: 'warning text', severity: SnackbarType.warning},
        ], {});

        const newStore = reducer(store, hideSnackbar());
        const result = view(snackbarState, newStore);

        expect(result).toIncludeAllMembers([
          {id: 'randomId', severity: SnackbarType.error, text: 'Error text'},
          {id: 'randomId', text: 'warning text', severity: SnackbarType.warning},
        ]);
      });
    });
  });
});

import { OverviewAction } from '../overview.actiontype';
import * as fromReducer from '../overview.reducer';
describe('Overview Reducer test suit', () => {
    it('should return the deafult state', () => {
        const { initialOverviewState } = fromReducer;
        const action = {
            type: 'Unknown'
          };
        const state = fromReducer.OverviewReducer(initialOverviewState, action);
        expect(state).toBe(initialOverviewState);
    });
});

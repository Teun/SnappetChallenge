import { reducer } from './sign.reducer';
import * as base from './sign.reducer';
import * as actions from '../../actions/signs/sign.action';
import { Filter } from 'app/store/reducers/BaseReducer';

describe('SignReducer', () => {
    describe('undefined action', () => {
        it('should return the default state', () => {
            const action = {} as any;

            const result = reducer(undefined, action);
            expect(result).toEqual(base.initialState);
        });
    });

    describe('LoginSign', () => {
        it('should authenticate sign', () => {
            const const1 = { userName: 'batman', password: 'killSuperman!' } as Nicollas.Dto.Identity.userDto;
            const requestAction = new actions.LogInRequestAction(const1)
            const completeAction = new actions.LogInCompleteAction({ } as Nicollas.Dto.Identity.tokenDto);

            let result = reducer(undefined, requestAction);
            expect(result).toEqual(Object.assign({}, base.initialState, { busy: true }));

            result = reducer(result, completeAction);
            expect(result).toEqual(Object.assign({}, base.initialState, { authenticated: true }));
        });
        it('should not authenticate sign', () => {
            const const1 = { userName: 'batman', password: 'killSuperman!' } as Nicollas.Dto.Identity.userDto;
            const requestAction = new actions.LogInRequestAction(const1)
            const completeAction = new actions.FailAction('error description');

            let result = reducer(undefined, requestAction);
            expect(result).toEqual(Object.assign({}, base.initialState, { busy: true }));

            result = reducer(result, completeAction);
            expect(result).toEqual(Object.assign({}, base.initialState, { error: 'error description' }));
        });
    });
});

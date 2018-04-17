/**
 * Every reducer module exports selector functions, however child reducers
 * have no knowledge of the overall state tree. To make them useable, we
 * need to make new selectors that wrap them.
 *
 * The createSelector function from the reselect library creates
 * very efficient selectors that are memoized and only recompute when arguments change.
 * The created selectors can also be composed together to select different
 * pieces of state.
 */

import * as fromReport from './report.reducer';

import { State } from 'app/store/reducers';
import { createSelector } from 'reselect/lib';

/**
 * A selector function is a map function factory. We pass it parameters and it
 * returns a function that maps from the larger state tree into a smaller
 * piece of state. This selector simply selects the `books` state.
 *
 * Selectors are used with the `select` operator.
 *
 * ```ts
 * class MyComponent {
 * 	constructor(state$: Observable<State>) {
 * 	  this.state$ = state$.select(getAdwordsAccount);
 * 	}
 * }
 * ```
 */
export const getState = (state: State) => state.report;
export const getAplyMonth = createSelector(getState, fromReport.getAplyMonth);
export const getAplyWeek = createSelector(getState, fromReport.getAplyWeek);

export const getDificultyWeek = createSelector(getState, fromReport.getDificultyWeek);
export const getProgressWeek = createSelector(getState, fromReport.getProgressWeek);

export const getDificultyByStudantWeek = createSelector(getState, fromReport.getdificultyByStudantWeek);
export const getProgressByStudantWeek = createSelector(getState, fromReport.getprogressByStudantWeek);

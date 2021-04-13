import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromOverview from './overview.reducer';

export const selectOverviewState = createFeatureSelector<fromOverview.OverviewState>('overview-raw-data');

/* Selector for retreving the rawData in Array format  */
export const selectAllOverview = createSelector(
    selectOverviewState,
    fromOverview.selectAll
);

/* Selector for knowing if Data has been already loaded, which is used in RouteResolver
     to improve the app performance */
export const isRawDataLoaded = createSelector(
    selectOverviewState,
    state => state.allOverviewDataLoaded
);

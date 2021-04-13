import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { Overview } from 'src/app/core/model/overview';
import { OverviewAction } from './overview.actiontype';

/* Feature State Name */
export const OverviewFeatureKey = 'overview-raw-data';

/* Define the OverviewSate with
  - Overview[] Data in Entity format
  - allOverViewDataLoaded, to know if the Data has been already loaded */
export interface OverviewState extends EntityState<Overview> {
  allOverviewDataLoaded: boolean;
}

/* Using Entity Adapter for managing collections */
export const adapter = createEntityAdapter<Overview>({selectId: Overview => Overview.SubmittedAnswerId});


/* Initial State*/
export const initialOverviewState = adapter.getInitialState({
  allOverviewDataLoaded: false
});

/* Reducer for updating the feature state, listening to overviewFetched Action  */
export const OverviewReducer = createReducer(
    initialOverviewState,
    on(OverviewAction.overviewFetched, (state, action) => adapter.setAll(action.overView,
      {...state, allOverviewDataLoaded: true}))
  );

/* Converting Entity format to Array has there is no CRUD operations so far*/
export const { selectAll } = adapter.getSelectors();

import { createAction, props } from '@ngrx/store';
import { Overview } from 'src/app/core/model/overview';

/* This action is dispatched from the route resolver at the application load time and it will
    be listened from the effects*/
export const fetchOverview = createAction(
'[Overview Resolver] Fetch Class Overview'
);

/* This action is called, when Effect is going to call the backend, in response the effect will also dispatch this overviewFetched
    Action in order to save the result in the store */
export const overviewFetched = createAction(
    '[Fetch Overview Effects] Overview is loaded',
    props<{overView: Overview[]}>()
);

/* This action is dispatched in case of error during the API request - logic need to be added */
export const overviewError = createAction(
    '[Error: Fetch Overview] Connection Error',
    props<{error: any}>()
);


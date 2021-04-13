import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, finalize, first, tap } from 'rxjs/operators';
import { AppState } from 'src/app/store/reducer';
import { OverviewAction } from './overview.actiontype';
import { isRawDataLoaded } from './overview.selectors';

@Injectable()
export class OverviewResolver implements Resolve<any>{

    /* Inorder to avoid multiple dispatch */
    loading = false;

    constructor(private store: Store<AppState>){}

    /*
        - Class Overview raw Data is loaded during the router resolving state, which is well before the rendering of the
      My Class Page component. And the resloved data is saved in the store
        - Dispatches the fetchOverview Action which inturns listened by the NgRx Side Effects
     */
    resolve(): Observable<any> {
        return this.store.pipe(
            select(isRawDataLoaded),
            tap(isDataLoaded => {
                if (!this.loading && !isDataLoaded){
                    this.loading = true;
                    this.store.dispatch(OverviewAction.fetchOverview());
                }
            }),
        /* Complete the route transition only if isDataLoaded is true */
        filter(isDataLoaded => isDataLoaded),
        /* waits for the above observable to emit one value & to make sure the observable completion & successful route transition, */
        first(),
        /* to reset the flag in case of successful or failed operation */
        finalize(() => this.loading = false)
        );
    }
}

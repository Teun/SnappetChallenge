import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, concatMap, map } from 'rxjs/operators';
import { ClassOverviewService } from 'src/app/core/services/class-overview/class-overview.service';
import { OverviewAction } from './overview.actiontype';

/* This is a NgRX SideEffect. 
    - which listens to the Fetch Overview Action & loads the data from backend 
    - and dispatche's the new action [OverviewAction.overviewFetched] whichs save the data to store
    - Incase of Error - route's to Error Page
                      - return custom Error Observable with default Error message & object
*/
@Injectable()
export class OverviewEffects {

    loadOverview$ = createEffect(() => this.action$.pipe(
        ofType(OverviewAction.fetchOverview),
        concatMap(() => this.httpService.fetchResults()),
        map( overView => {
            return OverviewAction.overviewFetched({overView});
        }),
        catchError(err => {
            this.router.navigateByUrl('/error-page');
            return of(OverviewAction.overviewError({error: ['Error occured', {error: err}]}));
        })));


    constructor(private action$: Actions, private httpService: ClassOverviewService,
                private router: Router){}
}

import { Component } from '@angular/core';
import { RealtimeService } from 'app/services/Socket/Realtime.service';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as actions from 'app/store/actions/signs/sign.action';

@Component({
    selector: 'app-root',
    template: `<base href="/"><router-outlet></router-outlet>`
})
export class AppComponent {
    constructor(private socket: RealtimeService, private store: Store<fromRoot.State>){
        store.select(s => s.sign.lastActionOnReducer)
        .distinctUntilChanged()
        .subscribe(data => {
           if (data === actions.LOG_IN_COMPLETE) {
                RealtimeService.Open();
           }
        });
    }
}

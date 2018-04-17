import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { APPCONFIG, LayoutAppConfig } from 'app/modules/shared/layout/configs';
import { MdSidenav } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as action from 'app/store/actions/signs/sign.action';
import * as screenfull from 'screenfull';
import { AuthGuard } from 'app/auth/auth.guard';

@Component({
    selector: 'app-sidenav-component',
    styleUrls: ['sidenav.component.scss'],
    templateUrl: './sidenav.component.html'
})

export class AppSidenavComponent implements OnInit {
    layoutConfig: LayoutAppConfig;
    authInformation: Observable<Nicollas.Dto.Identity.tokenDto>;

    @Input('sidenav')
    public sidenav: MdSidenav;

    constructor(private store: Store<fromRoot.State>, public guard: AuthGuard, private rd: Renderer2) {
        this.authInformation = store.select(s => s.sign.tokenResponse)
        this.layoutConfig = APPCONFIG;
    }

    ngOnInit() {
        if (screenfull.enabled) {
            if (this.layoutConfig.isScreenFull) {
                screenfull.request();
            } else {
                screenfull.exit();
            }
        }
    }

    logout() {
        this.store.dispatch(new action.LogoutRequestAction());
    }

    setFullScreen() {
        if (screenfull.enabled) {
            screenfull.toggle();
            this.layoutConfig.isScreenFull = !this.layoutConfig.isScreenFull;
        }
    }
}

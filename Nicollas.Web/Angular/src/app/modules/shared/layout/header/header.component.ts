import { Component, ViewChild, OnInit, Input } from '@angular/core';
import { MdSidenav } from '@angular/material';
import { LayoutAppConfig, APPCONFIG } from 'app/modules/shared/layout/configs';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'app-header-component',
    styleUrls: ['header.component.scss'],
    templateUrl: './header.component.html'
})

export class AppHeaderComponent implements OnInit {
    layoutConfig: LayoutAppConfig;
    authInformation: Observable<Nicollas.Dto.Identity.tokenDto>;


    @Input('sidenav')
    public sidenav: MdSidenav;

    constructor( private store: Store<fromRoot.State>) {
        this.authInformation = store.select(s => s.sign.tokenResponse)
    }

    ngOnInit() {
        this.layoutConfig = APPCONFIG;
    }
 }

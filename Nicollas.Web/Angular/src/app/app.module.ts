// augmentations.ts
import {Operator} from 'rxjs/Operator';
import {Observable} from 'rxjs/Observable';

// TODO: Remove this when a stable release of RxJS without the bug is available.
declare module 'rxjs/Subject' {
  interface Subject<T> {
    lift<R>(operator: Operator<T, R>): Observable<R>;
  }
}
// this part above need to be removed when rxjs update to an fix solution
// ===============================================================================

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule } from '@angular/forms'; // TODO: Nicollas: investigate if it's realy needed

// Materials 2
import { MaterialModule } from '@angular/material';

// Routing
import { AppRouting } from './app.routing';

// Injection custom services
import { Api } from './api.service';
import { AuthGuard } from 'app/auth/auth.guard';

// Modules that does not need to be on routing
import { AuthModule } from './auth/auth.module';
import { SignModule } from './modules/sign/sign.module';

// HTTP and RequestOptions are JTW deeps
import { HttpModule, JsonpModule } from '@angular/http';

// Root component
import { AppComponent } from './app.component';

// Redux ---
import { StoreModule } from '@ngrx/store';
import { reducers } from 'app/store/reducers';
import { EffectsModule } from '@ngrx/effects';
import { RealtimeService } from 'app/services/Socket/Realtime.service';

@NgModule({
    imports:
    [
        AppRouting,
        HttpModule,
        JsonpModule,
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        AuthModule,
        SignModule,

        /**
         * StoreModule.provideStore is imported once in the root module, accepting a reducer
         * function or object map of reducer functions. If passed an object of
         * reducers, combineReducers will be run creating your application
         * meta-reducer. This returns all providers for an @ngrx/store
         * based application.
         */
        StoreModule.forRoot(reducers),
        EffectsModule.forRoot([])
    ],
    providers: [
        Api,
        AuthGuard,
        RealtimeService
    ],
    declarations: [
        AppComponent,
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

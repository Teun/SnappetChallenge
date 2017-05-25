import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ReportingComponent } from './components/reporting/reporting.component';


@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ReportingComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        CommonModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'reporting', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'reporting', component: ReportingComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}

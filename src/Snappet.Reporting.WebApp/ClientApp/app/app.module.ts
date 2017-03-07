import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ChartPerSubjectComponent } from './components/chartpersubject/chartpersubject.component';
import { ReportPerLearningObjectiveComponent } from './components/reportperlearningobjective/reportperlearningobjective.component';
import { ChartsModule } from 'ng2-charts';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        ChartPerSubjectComponent,
        ReportPerLearningObjectiveComponent,
        HomeComponent
    ],
    imports: [
        UniversalModule, // must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        ChartsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'chart-per-subject', component: ChartPerSubjectComponent },
            { path: 'report-per-learning-objective', component: ReportPerLearningObjectiveComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}

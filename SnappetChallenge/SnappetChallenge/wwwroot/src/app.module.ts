import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { ToasterModule } from 'angular2-toaster';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { ProgressComponent } from './progress.component';
import { SubjectsComponent } from './subjects.component';
import { SubjectStatisticsComponent } from './subjectstatistics.component';
import { WorkService } from './work.service';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        SubjectsComponent,
        ProgressComponent,
        SubjectStatisticsComponent,
    ],
    imports: [
        BrowserModule,
        ChartsModule,
        HttpModule,
        routing,
        ToasterModule,
    ],
    providers: [
        WorkService,
    ],
})
export class AppModule {
}

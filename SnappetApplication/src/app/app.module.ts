import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentSummaryComponent } from './student-summary/student-summary.component';
import { ResultsServices } from './services/results.services';
import { HttpClientModule } from '@angular/common/http';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { AgGridModule } from 'ag-grid-angular';
import { StudentsServices } from './services/students.services';
import { StudentDetailsServices } from './student-details/student-details.services';
import { StudentSummaryServices } from './student-summary/student-summary.service';
import { StudentReportsComponent } from './student-reports/student-reports.component';
import { StudentReportServices } from './student-reports/student-reports.services';
import { ImagePreloadDirective } from './image-preload/image-preload.directive';
import { UiModule } from './ui/ui.module';

@NgModule({
  declarations: [
    AppComponent,
    StudentSummaryComponent,
    StudentDetailsComponent,
    StudentReportsComponent,
    ImagePreloadDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AgGridModule.withComponents(null),
    UiModule
  ],
  providers: [ResultsServices, StudentsServices, StudentDetailsServices, StudentSummaryServices, StudentReportServices],
  bootstrap: [AppComponent]
})
export class AppModule { }

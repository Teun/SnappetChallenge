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

@NgModule({
  declarations: [
    AppComponent,
    StudentSummaryComponent,
    StudentDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AgGridModule.withComponents(null)
  ],
  providers: [ResultsServices, StudentsServices, StudentDetailsServices, StudentSummaryServices],
  bootstrap: [AppComponent]
})
export class AppModule { }

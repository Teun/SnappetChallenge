import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SummaryComponent } from './summary/summary.component';
import { DomainSummaryComponent } from './domain-summary/domain-summary.component';
import { LearningObjectiveSummaryComponent } from './learning-objective-summary/learning-objective-summary.component';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SummaryService } from './services/summary.service';

const appRoutes: Routes = [
  { path: '', component: SummaryComponent },
  { path: 'domainsummary/:date/:subject', component: DomainSummaryComponent },
  { path: 'learningobjectivesummary/:date/:domain', component: LearningObjectiveSummaryComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SummaryComponent,
    DomainSummaryComponent,
    LearningObjectiveSummaryComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [SummaryService],
  bootstrap: [AppComponent]
})
export class AppModule { }

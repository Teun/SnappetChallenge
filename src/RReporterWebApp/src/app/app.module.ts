import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { WorkSummaryComponent } from './work-summary/work-summary.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    WorkSummaryComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'work-summary/:classId', component: WorkSummaryComponent },
      { path: 'not-found', component : NotFoundComponent},
      { path: '', redirectTo: '/work-summary/1', pathMatch: 'full' },
      { path: '**', redirectTo: '/not-found', pathMatch: 'full'}
    ]),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

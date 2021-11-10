import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ChartsModule } from 'ng2-charts';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DomainsBarChartComponent } from './components/domains-bar-chart/domains-bar-chart.component';
import { SubjectsPieChartComponent } from './components/subjects-pie-chart/subjects-pie-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    SubjectsPieChartComponent,
    DomainsBarChartComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, ChartsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

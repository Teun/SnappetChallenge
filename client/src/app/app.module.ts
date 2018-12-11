import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ChartsModule } from 'ng2-charts/ng2-charts';

// modules
import { AppMaterialModule } from './app-material.module';
import { AppRoutingModule } from './app-routing.module';

// components
import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { DataTableComponent } from './components/data-table/data-table.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FiltersComponent } from './components/filters/filters.component';
import { DoughnutChartComponent } from './components/doughnut-chart/doughnut-chart.component';

// services
import { DataService } from './services/data.service';
import { LocatorService } from './services/locator.service';
import { AppContextService } from './services/appcontext.service';

@NgModule({
  declarations: [
    AppComponent,
    DataTableComponent,
    DashboardComponent,
    DoughnutChartComponent,
    FiltersComponent,
    NavComponent
  ],
  imports: [
    AppMaterialModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    ChartsModule,
    FormsModule,
    HttpClientModule,
    LayoutModule,
    ReactiveFormsModule
  ],
  providers: [AppContextService,DataService, LocatorService ],
  bootstrap: [AppComponent]
})
export class AppModule {}

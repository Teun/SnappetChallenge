import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import {
  MatToolbarModule,
  MatButtonModule,
  MatSidenavModule,
  MatIconModule,
  MatListModule,
  MatTableModule,
  MatPaginatorModule,
  MatSortModule,
  MatGridListModule,
  MatCardModule,
  MatMenuModule,
  MatNativeDateModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatChipsModule
} from '@angular/material';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MainTableComponent } from './main-table/main-table.component';
import { MainDashboardComponent } from './main-dashboard/main-dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FiltersComponent } from './filters/filters.component';
import { DataService } from './services/data.service';
import { LocatorService } from './services/locator.service';
import { HttpClientModule } from '@angular/common/http';

import { ChartsModule } from 'ng2-charts/ng2-charts';
import { DoughnutChartComponent } from './doughnut-chart/doughnut-chart.component';
import { AppContextService } from './services/appcontext.service';

@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    MainTableComponent,
    MainDashboardComponent,
    FiltersComponent,
    DoughnutChartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatChipsModule,
    ChartsModule
  ],
  providers: [DataService, LocatorService, AppContextService],
  bootstrap: [AppComponent]
})
export class AppModule {}

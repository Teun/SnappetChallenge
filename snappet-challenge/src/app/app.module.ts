//NG
import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {RouterModule} from "@angular/router";
import {HttpClientModule} from '@angular/common/http';
import {NgChartsModule} from 'ng2-charts';

//Angular material
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatButtonToggleModule} from "@angular/material/button-toggle";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {MatProgressBarModule} from "@angular/material/progress-bar";

//Components
import {HomeComponent} from './components/home/home.component';
import {MenuComponent} from './components/_shared/menu/menu.component';
import {ChartComponent} from './components/_shared/chart/chart.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { ClassResultsComponent } from './components/home/class-results/class-results.component';
import { DomainResultsComponent } from './components/home/domain-results/domain-results.component';
import { CardComponent } from './components/_shared/card/card.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    ChartComponent,
    ClassResultsComponent,
    DomainResultsComponent,
    CardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatGridListModule,
    MatButtonToggleModule,
    MatSnackBarModule,
    MatProgressBarModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    NgChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AppModule {
}

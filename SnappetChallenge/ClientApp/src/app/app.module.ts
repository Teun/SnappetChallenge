import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EducatorTeachingOverviewComponent } from './educator-teaching-overview/educator-teaching-overview.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxMatDateAdapter, NgxMatDatetimePickerModule, NgxMatTimepickerModule, NGX_MAT_DATE_FORMATS } from '@angular-material-components/datetime-picker';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { NgxMatMomentAdapter, NgxMatMomentModule} from '@angular-material-components/moment-adapter';
import {MatButtonModule} from '@angular/material/button';

export const CUSTOM_MOMENT_FORMATS  = {
  parse: {
    dateInput: "l, LT"
  },
  display: {
    dateInput: "DD/MM/YYYY, LT",
    monthYearLabel: "MMM YYYY",
    dateA11yLabel: "LL",
    monthYearA11yLabel: "MMMM YYYY"
  }
};

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EducatorTeachingOverviewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatInputModule,
    MatButtonModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatMomentModule,
    NgxDatatableModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ], { relativeLinkResolution: 'legacy' }),
    NoopAnimationsModule
  ],
  providers: [
    { provide: NGX_MAT_DATE_FORMATS, useValue: CUSTOM_MOMENT_FORMATS },  
    { provide: NgxMatDateAdapter, useClass: NgxMatMomentAdapter },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {   
}

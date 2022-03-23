import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthComponent } from './month.component';
import {MatCardModule} from "@angular/material/card";
import {MatSelectModule} from "@angular/material/select";
import { SubjectSplitChartComponent } from './subject-split-chart/subject-split-chart.component';
import { NgChartsModule } from 'ng2-charts';
import { SubjectSuccessChartComponent } from './subject-success-chart/subject-success-chart.component';



@NgModule({
  declarations: [
    MonthComponent,
    SubjectSplitChartComponent,
    SubjectSuccessChartComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatSelectModule,
    NgChartsModule
  ]
})
export class MonthModule { }

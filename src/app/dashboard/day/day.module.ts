import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DayComponent } from './day.component';
import {MatCardModule} from "@angular/material/card";
import {MatIconModule} from "@angular/material/icon";
import { AnswersChartComponent } from './answers-chart/answers-chart.component';
import { NgChartsModule } from 'ng2-charts';
import {MatButtonModule} from "@angular/material/button";



@NgModule({
  declarations: [
    DayComponent,
    AnswersChartComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    NgChartsModule
  ]
})
export class DayModule { }

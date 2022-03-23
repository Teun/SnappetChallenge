import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import {RouterModule} from "@angular/router";
import {DayModule} from "./day/day.module";
import {MonthModule} from "./month/month.module";



@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    DayModule,
    MonthModule
  ]
})
export class DashboardModule { }

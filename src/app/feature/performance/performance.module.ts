import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PerformanceRoutingModule } from './performance-routing.module';
import { PerformancePageLayoutComponent } from './performance-page-layout/performance-page-layout.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChartsModule } from 'ng2-charts';


@NgModule({
  declarations: [
    PerformancePageLayoutComponent
  ],
  imports: [
    CommonModule,
    PerformanceRoutingModule,
    ChartsModule,
    SharedModule
  ]
})
export class PerformanceModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './pages/main/main.component';
import {SharedModule} from "@shared/shared.module";
import {OverviewRouting} from "@overview/overview.routing";



@NgModule({
  declarations: [
    MainComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    OverviewRouting
  ]
})
export class OverviewModule { }

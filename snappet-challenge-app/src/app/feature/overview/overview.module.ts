import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './pages/main/main.component';
import {SharedModule} from "@shared/shared.module";
import {OverviewRouting} from "@overview/overview.routing";
import { StudentsTableComponent } from './components/students-table/students-table.component';



@NgModule({
  declarations: [
    MainComponent,
    StudentsTableComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    OverviewRouting
  ],
  providers: []
})
export class OverviewModule { }

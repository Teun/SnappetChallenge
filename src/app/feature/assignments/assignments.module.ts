import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AssignmentsRoutingModule } from './assignments-routing.module';
import { AssignmentLayoutComponent } from './assignment-layout/assignment-layout.component';


@NgModule({
  declarations: [
    AssignmentLayoutComponent
  ],
  imports: [
    CommonModule,
    AssignmentsRoutingModule
  ]
})
export class AssignmentsModule { }

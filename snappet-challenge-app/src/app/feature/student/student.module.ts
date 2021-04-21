import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsListComponent } from './pages/students-list/students-list.component';
import { StudentComponent } from './pages/student/student.component';
import {SharedModule} from "@shared/shared.module";
import {StudentRouting} from "@student/student.routing";



@NgModule({
  declarations: [
    StudentsListComponent,
    StudentComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StudentRouting
  ],
  providers: []
})
export class StudentModule { }

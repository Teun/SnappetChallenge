import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentsLayoutComponent } from './students-layout/students-layout.component';

const routes: Routes = [
  {path: '', component: StudentsLayoutComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentsRoutingModule { }

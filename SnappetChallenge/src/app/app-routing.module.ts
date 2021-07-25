import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StudentReportingComponent } from 'student-reporting';

const routes: Routes = [
  { path: '', redirectTo: '/student-reporting', pathMatch: 'full' },
  { path: 'student-reporting', component: StudentReportingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

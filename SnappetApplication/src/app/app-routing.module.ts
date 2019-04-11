import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentSummaryComponent } from './student-summary/student-summary.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentReportsComponent } from './student-reports/student-reports.component';

const routes: Routes = [
  { path: 'results', component: StudentSummaryComponent },
  { path: 'results/:id', component: StudentDetailsComponent },
  { path: 'reports', component: StudentReportsComponent },
  { path: '', redirectTo: '/results', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentSummaryComponent } from './student-summary/student-summary.component';
import { StudentDetailsComponent } from './student-details/student-details.component';

const routes: Routes = [
  { path: 'results', component: StudentSummaryComponent },
  { path : 'results/:id', component: StudentDetailsComponent},
  { path: '', redirectTo: '/results', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

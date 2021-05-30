import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExerciseListComponent } from './components/exercise-list/exercise-list.component';
import { ExerciseOverviewComponent } from './components/exercise-overview/exercise-overview.component';
import { StudentOverviewComponent } from './components/student-overview/student-overview.component';

const routes: Routes = [
  { path: '', component: StudentOverviewComponent },
  { path: 'exerciseOverview', component: ExerciseOverviewComponent },
  { path: 'exercises', component: ExerciseListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

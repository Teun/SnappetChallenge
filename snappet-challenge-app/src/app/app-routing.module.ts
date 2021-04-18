import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {EXERCISE_ROUTE, OVERVIEW_ROUTE, STUDENT_ROUTE} from "./routes";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'overview'
  },
  {
    ...OVERVIEW_ROUTE,
    loadChildren: (): Promise<unknown> =>
      import('@overview/overview.module').then((m) => m.OverviewModule),
  },
  {
    ...STUDENT_ROUTE,
    loadChildren: (): Promise<unknown> =>
      import('@student/student.module').then((m) => m.StudentModule),
  },
  {
    ...EXERCISE_ROUTE,
    loadChildren: (): Promise<unknown> =>
      import('@exercise/exercise.module').then((m) => m.ExerciseModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

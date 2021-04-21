import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {OVERVIEW_ROUTE, STUDENT_ROUTE} from "./routes";

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
    path: '**',
    redirectTo: 'overview',
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

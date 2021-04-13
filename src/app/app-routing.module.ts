import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './shared/ui-components/error-page/error-page.component';

const routes: Routes = [
  {path: 'class-performance', loadChildren: () => import('./feature/performance/performance.module').then(m => m.PerformanceModule)},
  {path: 'assignments', loadChildren: () => import('./feature/assignments/assignments.module').then(m => m.AssignmentsModule)},
  {path: 'students', loadChildren: () => import('./feature/students/students.module').then(m => m.StudentsModule)},
  {path: 'error-page', component: ErrorPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

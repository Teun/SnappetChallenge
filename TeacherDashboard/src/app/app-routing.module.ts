import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnswersPageComponent } from './page/answers-page/answers-page.component';
import { UsersPageComponent } from './page/users-page/users-page.component';

const routes: Routes = [
  {
    path: 'answers',
    component: AnswersPageComponent
  },
  {
    path: 'students',
    component: UsersPageComponent
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'answers'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

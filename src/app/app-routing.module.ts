import {NgModule} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import {AnswersContainer} from "./containers/answers.container";
import {StatisticsContainer} from "./containers/statistics.container"; // CLI imports router

const routes: Routes = [
  {
    path: 'answers',
    component: AnswersContainer,
  },
  {
    path: 'statistics',
    component: StatisticsContainer,
  },
  {
    path: '',
    redirectTo: 'answers',
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DailyInsightsComponent  } from './daily-insights/daily-insights.component';
const routes: Routes = [
  { path: '', redirectTo: '/daily', pathMatch: 'full' },
  { path: 'daily', component: DailyInsightsComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

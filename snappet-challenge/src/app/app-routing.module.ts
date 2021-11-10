import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DomainsBarChartComponent } from './components/domains-bar-chart/domains-bar-chart.component';
import { SubjectsPieChartComponent } from './components/subjects-pie-chart/subjects-pie-chart.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: '',
        component: SubjectsPieChartComponent,
      },
      {
        path: 'domains',
        component: DomainsBarChartComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

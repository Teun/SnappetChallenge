import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { BaseComponent } from 'app/modules/shared/layout/base.component';
import { AuthGuard } from 'app/auth/auth.guard';
import { ReportsComponent } from './reports/reports.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  {
    path: '', component: BaseComponent, canActivateChild: [AuthGuard],
    children: [
      { path: '', component: WelcomeComponent, pathMatch: 'full'},
      { path: 'Charts', component: ReportsComponent }
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}

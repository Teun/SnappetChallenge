import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { BaseComponent } from 'app/modules/shared/layout/base.component';
import { UsersComponent } from 'app/modules/admin/users/users.component';
import { AuthGuard } from 'app/auth/auth.guard';
import { ReportsComponent } from './reports/reports.component';

const routes: Routes = [
  {
    path: '', component: BaseComponent, canActivateChild: [AuthGuard],
    children: [
      { path: '', redirectTo: 'Tables', pathMatch: 'full', data: {'claims': ['Table'] }},
      { path: 'Users', component: UsersComponent, data: {'claims': ['User'] } },
      { path: 'Charts', component: ReportsComponent },
      // { path: 'Table/:id', component: TablesComponent },
      // { path: 'User/:id', component: UsersComponent },
      // { path: 'role/:id', component: RolesComponent },
      // { path: 'Product/:id', component: TablesComponent },
      // { path: 'Category/:id', component: CategoriesComponent },
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}

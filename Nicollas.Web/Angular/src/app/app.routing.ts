import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from 'app/auth/auth.guard';

const routes: Routes = [
    { path: '', loadChildren: 'app/modules/admin/admin.module#AdminModule', canActivate: [AuthGuard]},
    { path: 'Admin', loadChildren: 'app/modules/admin/admin.module#AdminModule', canActivate: [AuthGuard]},
];

export const AppRouting = RouterModule.forRoot(routes);

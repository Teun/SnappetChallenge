import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyClassPageLayoutComponent } from './my-class-page-layout/my-class-page-layout.component';
import { OverviewResolver } from './store/overview.resolver';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/class-overview'},
  {path: 'class-overview', component: MyClassPageLayoutComponent, resolve: {overview: OverviewResolver}},
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class MyClassRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PerformancePageLayoutComponent } from './performance-page-layout/performance-page-layout.component';

const routes: Routes = [
  {path: '', component: PerformancePageLayoutComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PerformanceRoutingModule { }

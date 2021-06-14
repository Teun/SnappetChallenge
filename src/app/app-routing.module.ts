import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateDataBackendComponent } from './components/create-data-backend/create-data-backend.component';
import { WorkComponent } from './components/work/work.component';

const routes: Routes = [
  { path: 'create-backend', component: CreateDataBackendComponent },
  { path: '', component: WorkComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


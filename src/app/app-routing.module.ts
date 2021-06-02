import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateDataBackendComponent } from './components/create-data-backend/create-data-backend.component';

const routes: Routes = [
  { path: 'init', component: CreateDataBackendComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


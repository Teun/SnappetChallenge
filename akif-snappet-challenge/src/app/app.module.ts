import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ClassChartsComponent } from './pages/class-charts/class-charts.component';
import { RouterModule } from '@angular/router';

const ROUTES = [{
  path:'',
  component:ClassChartsComponent
}]

@NgModule({
  declarations: [
    AppComponent,
    ClassChartsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

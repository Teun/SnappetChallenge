import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { DomainNames } from './models/class.model';
import { NgxEchartsModule } from 'ngx-echarts';
import { ActualLevelEstimationComponent } from './pages/actual-level-estimation/actual-level-estimation.component';
import { RelativeProgressComponent } from './pages/relative-progress/relative-progress.component';
import { SpinnerComponent } from './components/spinner/spinner.component';

const domains = DomainNames;

const ROUTES = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'actual-level',
  },
  {
    path: 'actual-level',
    component: ActualLevelEstimationComponent,
  },
  {
    path: 'relative-progress',
    component: RelativeProgressComponent,
  },
];

@NgModule({
  declarations: [AppComponent, ActualLevelEstimationComponent, RelativeProgressComponent, SpinnerComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts'),
    }),
    RouterModule.forRoot(ROUTES),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

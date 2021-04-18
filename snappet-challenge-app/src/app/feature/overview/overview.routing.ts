import {RouterModule, Routes} from "@angular/router";
import {MainComponent} from "@overview/pages/main/main.component";

const routes: Routes = [
  {
    path: '',
    component: MainComponent
  }
];

export const OverviewRouting = RouterModule.forChild(routes);

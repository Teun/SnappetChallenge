import { Routes } from '@angular/router';
import { MainPageComponent } from './pages/sc-main-page.component';

export const appRouter: Routes = [
  { path: '', component: MainPageComponent } //,
//   { path: 'restaurant/:id', component: RestaurantPageComponent,
//     resolve: {
//       meals: MealsResolver,
//       restaurant: RestaurantResolver
//     }
//   },
]

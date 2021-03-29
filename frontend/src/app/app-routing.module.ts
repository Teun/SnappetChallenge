import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserActivityComponent } from './user-activity/user-activity.component';
import { UserProgressComponent } from './user-progress/user-progress.component';
import { ExercisesComponent } from './exercises/exercises.component';

const routes: Routes = [
    { path: '', redirectTo: '/activities', pathMatch: 'full' },
    { path: 'activities', component: UserActivityComponent },
    { path: 'progress', component: UserProgressComponent },
    { path: 'exercises', component: ExercisesComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}

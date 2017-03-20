import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProgressComponent } from './progress.component';
import { SubjectsComponent } from './subjects.component';
import { SubjectStatisticsComponent } from './subjectstatistics.component';

const appRoutes: Routes = [
    {
        component: SubjectsComponent,
        path: 'subjects',
    },
    {
        component: ProgressComponent,
        path: 'progress',
    },
    {
        component: SubjectStatisticsComponent,
        path: 'subjects/:subject',
    },
    {
        path: '',
        pathMatch: 'full',
        redirectTo: '/subjects',
    },

];

export const routing: ModuleWithProviders = RouterModule
    .forRoot(appRoutes);

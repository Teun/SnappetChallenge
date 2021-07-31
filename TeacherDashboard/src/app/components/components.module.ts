import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';

import { OverlayLoadingComponent } from './overlay-loading/overlay-loading.component';
import { ListExcercisesComponent } from './list-excercise/list-excercises.component';
import { ListSubjectGroupsComponent } from './list-subject-groups/list-subject-groups.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
  imports: [
    CommonModule,

    NgxChartsModule,

    MatTabsModule,
    MatTableModule,
    MatExpansionModule,
    MatProgressSpinnerModule
  ],
  declarations: [
    OverlayLoadingComponent,
    ListExcercisesComponent,
    ListSubjectGroupsComponent
  ],
  exports: [
    NgxChartsModule,

    OverlayLoadingComponent,
    ListExcercisesComponent,
    ListSubjectGroupsComponent
  ]
})
export class ComponentsModule { }

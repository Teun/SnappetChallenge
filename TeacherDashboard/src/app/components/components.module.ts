import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';

import { OverlayLoadingComponent } from './overlay-loading/overlay-loading.component';
import { ListExcercisesComponent } from './list-excercise/list-excercises.component';
import { ListSubjectGroupsComponent } from './list-subject-groups/list-subject-groups.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ListStudentsComponent } from './list-students/list-students.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SummaryStudentComponent } from './summary-student/summary-student.component';
import { GraphSubjectGroupsComponent } from './graph-subject-groups/graph-subject-groups.component';
import { GraphObjectivesComponent } from './graph-objectives/graph-objectives.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    NgxChartsModule,

    MatTabsModule,
    MatTableModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule
  ],
  declarations: [
    OverlayLoadingComponent,
    ListExcercisesComponent,
    ListSubjectGroupsComponent,
    ListStudentsComponent,
    SummaryStudentComponent,
    GraphSubjectGroupsComponent,
    GraphObjectivesComponent
  ],
  exports: [
    NgxChartsModule,

    OverlayLoadingComponent,
    ListSubjectGroupsComponent,
    ListStudentsComponent,
    GraphSubjectGroupsComponent,
    SummaryStudentComponent
  ]
})
export class ComponentsModule { }

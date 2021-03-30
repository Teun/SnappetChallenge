import { NgModule } from '@angular/core';
import { TeacherDashboardComponent } from './teacher/teacher-dashboard/teacher-dashboard.component';
import { StudentOverviewComponent } from './student/student-overview/student-overview.component';
import { SchoolComponent } from './school.component';
import { MaterialModule } from '../../material.module';

@NgModule({
  declarations: [
    TeacherDashboardComponent,
    StudentOverviewComponent,
    SchoolComponent,
  ],
  imports: [MaterialModule],
})
export class SchoolModule {}

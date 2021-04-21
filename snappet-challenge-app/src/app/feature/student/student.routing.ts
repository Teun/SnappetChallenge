import {RouterModule, Routes} from "@angular/router";
import {StudentsListComponent} from "@student/pages/students-list/students-list.component";
import {StudentComponent} from "@student/pages/student/student.component";

const routes: Routes = [
  {
    path: '',
    component: StudentsListComponent,
  },
  {
    path: ':id',
    component: StudentComponent
  }
];

export const StudentRouting = RouterModule.forChild(routes);

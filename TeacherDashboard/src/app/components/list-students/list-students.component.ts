import { Component, Input } from '@angular/core';
import { Student } from '../../objects/student';

@Component({
  selector: 'app-list-students',
  templateUrl: './list-students.component.html',
  styleUrls: ['./list-students.component.scss']
})
export class ListStudentsComponent {
  @Input()
  public students!: Array<Student>;
  public student: Student | undefined;
}

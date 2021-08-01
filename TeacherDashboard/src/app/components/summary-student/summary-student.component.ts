import { Component, Input, OnInit } from '@angular/core';
import { Student } from '../../objects/student';

@Component({
  selector: 'app-summary-student',
  templateUrl: './summary-student.component.html',
  styleUrls: ['./summary-student.component.scss']
})
export class SummaryStudentComponent {
  @Input()
  public student!: Student;
}

import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { StudentService } from '../student.service';
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css'],
})
export class StudentComponent implements OnInit {
  constructor(private studentService: StudentService) {}
  //Event to Output the studentId is declared
  @Output() updatedEvent = new EventEmitter<number>();
  students: number[] = [];
  currentStudent: number = 0;
  activeStudent: Number = 0;

  //This event is triggered when the student userId is clicked from the students list on sidebar
  public discoverClicked(student: number) {
    this.activeStudent = student; //Get the student id to the variable
    this.updatedEvent.emit(student); //Emmit an event with the studentId so it can be used by parent component and sent to studentDetails component
  }

  //OnInit is set to load the list of unique studentId's on sidebar
  ngOnInit() {
    this.studentService.getStudents().subscribe((result: any) => { //Fetch the unique studentIds
      result.map((data: number, index: number) => {
        this.students.push(data); //Push studentIds to student list to show on front end
      });
    });
  }
}

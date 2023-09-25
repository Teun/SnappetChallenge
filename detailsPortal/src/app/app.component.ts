import { Component } from '@angular/core';
interface StudentData {
  SubmittedAnswerId: Number;
  ExerciseId: Number;
  Difficulty: Number;
  Subject: String;
  LearningObjective: String;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = '';
  studentCurrent: Number = 0;

  /*This acts as a bridge to take selected studentId from student component and set to 
  current selected student variable i.e studentCurrent so this variable can be used by student-details component
  */
  gotData($event: number) {
    this.studentCurrent = $event;
  }
}

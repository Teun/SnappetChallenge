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
  title = 'Snappet Class';
  studentCurrent: Number = 0;

  gotData($event: number) {
    this.studentCurrent = $event;
  }
}

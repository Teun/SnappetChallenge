import { Component, Input } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'sc-table',
  template: `
  <div class="table-responsive">
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Student</th>
          <th>Subject</th>
          <th>Class Domain</th>
          <th>Learning Objective</th>
          <th>Total Exercises</th>
          <th>Correct</th>
          <th>Wrong</th>
          <th>Accuracy</th>
        </tr>
      </thead>
      <tbody>
        <tr *ngFor="let student of students">
          <td>{{student.UserId}}</td>
          <td>{{student.Subject}}</td>
          <td>{{student.ClassDomain}}</td>
          <td>{{student.LearningObjective}}</td>
          <td>{{student.TotalExercises}}</td>
          <td>{{student.Correct}}</td>
          <td>{{student.Wrong}}</td>
          <td><span
            class="badge"
            [ngClass]="{
              'badge-danger': student.Accuracy <= 20,
              'badge-warning': student.Accuracy > 20 && student.Accuracy <= 50,
              'badge-info': student.Accuracy > 50 && student.Accuracy <= 80,
              'badge-success': student.Accuracy > 80
              }">
            {{student.Accuracy}} %</span></td>
        </tr>
      </tbody>
    </table>
  </div>
  `
})
export class TableComponent implements OnInit {

  @Input() students: any[];
  collapsed = false;

  toggle() {
    this.collapsed = !this.collapsed;
  }

  ngOnInit() {
    // this.students = [
    //   {
    //       'UserId': 40267,
    //       'Subject': 'Rekenen',
    //       'ClassDomain': 'Getallen',
    //       'LearningObjective': 'Gehele getallen plaatsen op getallenlijn\r',
    //       'TotalExercises': 22,
    //       'Correct': 15,
    //       'Wrong': 7,
    //       'Accuracy': 68.18
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Rekenen',
    //       'ClassDomain': 'Getallen',
    //       'LearningObjective': 'Optellen en aftrekken tot ',
    //       'TotalExercises': 35,
    //       'Correct': 23,
    //       'Wrong': 12,
    //       'Accuracy': 65.71
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Rekenen',
    //       'ClassDomain': 'Getallen',
    //       'LearningObjective': 'Tafelsommen\r',
    //       'TotalExercises': 7,
    //       'Correct': 7,
    //       'Wrong': 0,
    //       'Accuracy': 100
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Rekenen',
    //       'ClassDomain': 'Getallen',
    //       'LearningObjective': 'Tafelsommen 6 t/m 9\r',
    //       'TotalExercises': 1,
    //       'Correct': 1,
    //       'Wrong': 0,
    //       'Accuracy': 100
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Rekenen',
    //       'ClassDomain': 'Getallen',
    //       'LearningObjective': 'Vermenigvuldigen 8 x 32\r',
    //       'TotalExercises': 31,
    //       'Correct': 10,
    //       'Wrong': 21,
    //       'Accuracy': 32.26
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Rekenen',
    //       'ClassDomain': 'Meten',
    //       'LearningObjective': 'Inzicht in relatie 3D en 2D\r',
    //       'TotalExercises': 17,
    //       'Correct': 8,
    //       'Wrong': 9,
    //       'Accuracy': 47.06
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Spelling',
    //       'ClassDomain': 'Taalverzorging',
    //       'LearningObjective': '\'klinkerverenkeling (straten',
    //       'TotalExercises': 4,
    //       'Correct': 4,
    //       'Wrong': 0,
    //       'Accuracy': 100
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Spelling',
    //       'ClassDomain': 'Taalverzorging',
    //       'LearningObjective': '\'medeklinkerverdubbeling (bruggen',
    //       'TotalExercises': 1,
    //       'Correct': 1,
    //       'Wrong': 0,
    //       'Accuracy': 100
    //     },
    //     {
    //       'UserId': 40267,
    //       'Subject': 'Spelling',
    //       'ClassDomain': 'Taalverzorging',
    //       'LearningObjective': '\'samengestelde woorden (tuindeur',
    //       'TotalExercises': 4,
    //       'Correct': 1,
    //       'Wrong': 3,
    //       'Accuracy': 25
    //     }
    // ];
  }

}

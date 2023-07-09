import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

export interface Answer {
  Correct: number;
  Difficulty: string;
  Domain: string;
  ExerciseId: number;
  LearningObjective: string;
  Progress: number;
  Subject: string;
  SubmitDateTime: string;
  SubmittedAnswerId: number;
  UserId: number;
}
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
})
export class AppComponent implements OnInit {
  dateChoices: string[] = ['today', 'this-week'];
  students: {};
  dataSource: any[] = [];
  displayedColumns: any[] = [];

  constructor(private http: HttpClient) {}

  onChange() {
    this.dateChoices = this.dateChoices.reverse();
    this.fetchData();
  }

  fetchData() {
    this.http
      .get<any>(`${environment.API_ENDPOINT}?date=${this.dateChoices[0]}`)
      .subscribe(
        (data) => {
          [this.dataSource, this.displayedColumns] = this._processData(
            data.items
          );
          console.log(this.dataSource);
        },
        (error) => {
          console.error('Error fetching data from the API:', error);
        }
      );
  }
  format(el, column) {
    if (column === 'UserId') return el[column];
    if (!el[column].ExerciseId) return ``;
    return `Exercise: ${el[column].ExerciseId}\nProgress: ${el[column].Progress}`;
  }
  _processData(data: Answer[]) {
    // Group the data by UserId
    const groupedData = data.reduce((acc, exercise) => {
      const { UserId, SubmitDateTime, ...rest } = exercise;
      if (!acc[UserId]) {
        acc[UserId] = { UserId };
      }
      acc[UserId][SubmitDateTime] = rest;
      return acc;
    }, {});

    // Extract unique SubmitDateTime values
    const submitDateTimes = [
      ...new Set(data.map((exercise) => exercise.SubmitDateTime)),
    ]
      .sort()
      .reverse();

    // Convert groupedData object into an array of user objects
    const result = Object.values(groupedData);

    // Add missing SubmitDateTime properties with a value of 0
    result.forEach((user) => {
      submitDateTimes.forEach((dateTime: string) => {
        if (!user.hasOwnProperty(dateTime)) {
          user[dateTime] = ``;
        }
      });
    });
    console.log(result);
    return [result, ['UserId', ...submitDateTimes]];
  }

  ngOnInit() {
    this.fetchData();
  }
}

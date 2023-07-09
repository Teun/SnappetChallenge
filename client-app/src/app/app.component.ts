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
  dateChoices: string[] = ['today', 'this week'];
  students: {};
  dataSource: any = {};
  displayedColumns: any[] = [];
  loading: boolean = false;
  cache: any = {};
  Object = Object;
  showAnswers: { [student: string]: boolean } = {};

  constructor(private http: HttpClient) {}

  toggleAnswers(student: string) {
    this.showAnswers[student] = !this.showAnswers[student];
  }

  onChange() {
    this.dateChoices = this.dateChoices.reverse();
    this.fetchData();
  }

  aggregateArrayByKey(arr: Array<any>, key: string): any {
    return arr.reduce((result, obj) => {
      const value = obj[key];
      if (!result[value]) {
        result[value] = [];
      }
      result[value].push(obj);
      return result;
    }, {});
  }

  fetchData() {
    this.loading = true;

    if (this.cache[this.dateChoices[0]]) {
      this.dataSource = this.cache[this.dateChoices[0]];
      this.loading = false;
      return;
    }

    this.http
      .get<any>(`${environment.API_ENDPOINT}?date=${this.dateChoices[0]}`)
      .subscribe(
        (data) => {
          const res = this.aggregateArrayByKey(data.items, 'UserId');
          Object.keys(res).forEach((user) => {
            res[user] = this.aggregateArrayByKey(
              res[user],
              'LearningObjective'
            );
          });

          this.dataSource = res;
          console.log(this.dataSource);
          this.cache[this.dateChoices[0]] = this.dataSource;
          this.loading = false;
        },
        (error) => {
          console.error('Error fetching data from the API:', error);
          this.loading = false;
        }
      );
  }

  ngOnInit() {
    this.fetchData();
  }
}

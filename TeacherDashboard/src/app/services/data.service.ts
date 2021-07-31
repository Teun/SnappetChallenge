import { Injectable } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Answer } from '../interfaces/answer';
import { Excercise } from '../interfaces/excercise';
import { SubjectGroup } from '../interfaces/subject-group';
import { HttpService } from './http.service';

const TODAY_STRING = '2015-03-24 11:30:00 UTC';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private _data: BehaviorSubject<Array<Answer>>;
  private _date: BehaviorSubject<Date>;

  constructor(private http: HttpService) {
    this._data = new BehaviorSubject([] as Array<Answer>);
    this._date = new BehaviorSubject(new Date(TODAY_STRING));

    this.http
      .get('/assets/work.json')
      .pipe(
        map(data => data.map((item: Answer) => {
          item.SubmitDateTime = new Date(item.SubmitDateTime);
          item.Correct = Boolean(item.Correct);
          return item;
        }))
      )
      .subscribe(data => this._data.next(data));
  }

  public get data(): Observable<Array<Answer>> {
    return this._data;
  }

  public get date(): Observable<Date> {
    return this._date;
  }

  public getDate(): Date {
    return new Date(this._date.value.toUTCString());
  }

  public setDateToday(): void {
    const today = new Date(TODAY_STRING);
    if (!this.isToday()) {
      this._date.next(today);
    }
  }

  public isToday(): Boolean {
    const today = new Date(TODAY_STRING);
    return this.getDate().getTime() == today.getTime();
  }

  public setDate(date?: Date) {
    const today = new Date(TODAY_STRING);
    if (!date || date.getTime() > today.getTime()) {
      this.setDateToday()
    } else {
      this._date.next(date);
    }
  }

  public getDataForDate(): Observable<Array<Answer>> {
    return combineLatest([this.date, this._data])
      .pipe(
        map(([date, data]) => data.filter(item => this.isOnDate(date, item.SubmitDateTime)))
      )
  }

  public getSubjectGroupsForDate(): Observable<Array<SubjectGroup>> {
    return this.getDataForDate()
      .pipe(
        map(data => data.reduce((accumulator, item) => {
          if (!accumulator[item.ExerciseId]) {
            accumulator[item.ExerciseId] = {
              id: item.ExerciseId,
              submissions: 0,
              difficulty: item.Difficulty,
              subject: item.Subject,
              objective: item.LearningObjective,
              progress: []
            }
          }

          accumulator[item.ExerciseId].submissions++;
          if (item.Progress != 0) {
            accumulator[item.ExerciseId].progress.push(item.Progress);
          }

          return accumulator;
        }, {} as { [key: string]: Excercise })),
        map(reduced => Object.keys(reduced).map(key => reduced[key]).reduce((accumulator, item) => {
          if (!accumulator[item.subject]) {
            accumulator[item.subject] = {
              subject: item.subject,
              objectives: {
                [item.objective]: [item]
              }
            };
          } else if (!accumulator[item.subject].objectives[item.objective]) {
            accumulator[item.subject].objectives[item.objective] = [item];
          } else {
            accumulator[item.subject].objectives[item.objective].push(item);
          }

          return accumulator;
        }, {} as { [key: string]: { subject: string, objectives: { [key: string]: [Excercise] } } })),
        map(reduced => Object.keys(reduced).map(key => reduced[key]).reduce((accumulator, item) => {
          accumulator.push({
            subject: item.subject,
            objectives: Object.keys(item.objectives)
              .map(key => ({
                objective: key,
                excercises: item.objectives[key],
                answers: this.answerCount(item.objectives[key])
              }))
              .sort((a, b) => b.answers - a.answers)
          });
          return accumulator;
        }, [] as Array<SubjectGroup>))
      )
  }

  private answerCount(excercises: Array<Excercise>): number {
    return excercises.reduce((accumulator, item) => accumulator + item.submissions, 0);
  }

  private isOnDate(date: Date, answerDate: Date): Boolean {
    return date.getFullYear() === answerDate.getFullYear() &&
      date.getMonth() === answerDate.getMonth() &&
      date.getDate() === answerDate.getDate() &&
      date.getTime() >= answerDate.getTime();
  }
}

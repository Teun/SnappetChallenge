import { Injectable } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Answer } from '../interfaces/answer';
import { DataHolder } from '../objects/data-holder';
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

  public getAnswersForDate(): Observable<DataHolder> {
    return combineLatest([this.date, this._data])
      .pipe(
        map(([date, data]) => data.filter(item => this.isOnDate(date, item.SubmitDateTime))),
        map(answers => answers.reduce((parser, answer) => parser.addAnswer(answer), new DataHolder()))
      );
  }

  private isOnDate(date: Date, answerDate: Date): Boolean {
    return date.getFullYear() === answerDate.getFullYear() &&
      date.getMonth() === answerDate.getMonth() &&
      date.getDate() === answerDate.getDate() &&
      date.getTime() >= answerDate.getTime();
  }
}

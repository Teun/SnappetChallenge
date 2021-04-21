import { Injectable } from '@angular/core';
import {ApiAnswer} from "@core/interfaces/api-answer.interface";
import {BehaviorSubject, Observable} from "rxjs";
import {ApiOverviewService} from "@core/services/api-overview.service";
import {first, map, tap} from "rxjs/operators";
import {ChartItem} from "@core/interfaces/chart-item.interface";
import {IntervalService} from "@core/services/interval.service";

@Injectable({
  providedIn: 'root'
})
export class OverviewService {
  fetchedAnswers: ApiAnswer[] = [];
  private _filteredAnswers$ = new BehaviorSubject<ApiAnswer[]>([]);

  get filteredAnswers$(): Observable<ApiAnswer[]> {
    return this._filteredAnswers$.asObservable();
  }

  get mostDifficultExercises$(): Observable<ChartItem[]> {
    return this._filteredAnswers$.pipe(map((data) => {
      const exercises: ChartItem[] = [];
      data.forEach((answer) => {
        const existedExerciseIndex = exercises.findIndex(el => el.name === answer.ExerciseId.toString());
        if (existedExerciseIndex !== -1) {
          exercises[existedExerciseIndex].value += answer.Correct === 0 ? 1 : 0;
        } else {
          exercises.push({name: answer.ExerciseId.toString(), value: 0});
        }
      })
      return exercises;
    }));
  }

  constructor(
    private apiOverviewService: ApiOverviewService,
    private intervalService: IntervalService,
  ) {
    this.intervalService.filter$.subscribe(() => {
      this.filterAnswers();
    })
  }

  getAnswers(): Observable<ApiAnswer[]> {
    if (this.fetchedAnswers.length) {
      return this._filteredAnswers$.pipe(first());
    }
    return this.apiOverviewService.getOverview()
      .pipe(tap((data) => {
        this.fetchedAnswers = data;
        this.filterAnswers();
      }));
  }

  getStudentStatistics(id: number): Observable<ApiAnswer[]> {
    return this._filteredAnswers$.pipe(
      map((answers) => answers.filter(el => el.UserId === id))
    );
  }

  private filterAnswers(){
    const filteredData = this.fetchedAnswers.filter((el) =>
      new Date(el.SubmitDateTime) >= this.intervalService.filterValue.from &&
      new Date(el.SubmitDateTime) <= this.intervalService.filterValue.to);
    this._filteredAnswers$.next(filteredData);
  }
}

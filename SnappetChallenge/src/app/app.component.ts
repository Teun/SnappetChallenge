import { Component, OnInit } from '@angular/core';
import { StudentAverage, SubjectAverage } from './models/student-results.model';

import { first } from 'rxjs/operators';

import { DataStoreService } from './services/data-store.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'SnappetChallenge';

  // Student Averages
  public studentResults: StudentAverage[] = [];
  // Subject Averages
  public subjectsAverages: SubjectAverage[] = [];
  // Date list
  public dates: Array<string> = [];
  // Subject breadown per day
  public dayBreakdown: Array<SubjectAverage> = []

  constructor(
    private dataStoreService: DataStoreService
  ) {

  }

  public ngOnInit(): void {
    this.getData();
    this.getDates();
  }

  private getData(): void {
    this.dataStoreService.studentResultsObservable.subscribe((response: StudentAverage) => {
      this.studentResults.push(response);
    });

    this.dataStoreService.subjectsObservable.subscribe((response: SubjectAverage) => {
      this.subjectsAverages.push(response);
    });
  }

  private getDates(): void {
    this.dataStoreService.datesObserver.subscribe((response: Array<string>) => {
      this.dates = response;
    });
  }

  public getDayBreakdown(date: string) {
    this.dataStoreService.getDayBreakdown(date);

    this.dataStoreService.dayBreakdownObservable.pipe(first()).subscribe((response: any) => { // "first()" to prevent memory leak when selecting from the dates dropdown multiple times.
      this.dayBreakdown = response;
    });
  }
}

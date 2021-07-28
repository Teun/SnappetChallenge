import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ReplaySubject, from } from 'rxjs';
import { mergeMap, groupBy, toArray } from 'rxjs/operators';

import { StudentResults, StudentAverage, SubjectAverage } from '../models/student-results.model';

@Injectable({
  providedIn: 'root'
})
export class DataStoreService {

  private studentResultsSubject = new ReplaySubject<StudentAverage>(1);
  public studentResultsObservable = this.studentResultsSubject.asObservable();

  private subjectsSubject = new ReplaySubject<SubjectAverage>(1);
  public subjectsObservable = this.subjectsSubject.asObservable();

  private datesSubject = new ReplaySubject<Array<string>>(1);
  public datesObserver = this.datesSubject.asObservable();

  private dayBreakdownSubject = new ReplaySubject<Array<SubjectAverage>>(1);
  public dayBreakdownObservable = this.dayBreakdownSubject.asObservable();

  private dates: Array<string> = [];
  private dataSet: StudentResults[] = [];

  // Would abstract this to an API layer.  
  constructor(
    private http: HttpClient,
  ) {
    this.http.get<Array<StudentResults>>("./assets/work.json").subscribe(
      (response: Array<StudentResults>) => {
        this.orderByUserID(response);
        this.orderBySubject(response);
        this.setDates(response);
        this.dataSet = response;
      }
    );
  }

  private orderByUserID(studentResults: Array<StudentResults>): void {
    from(studentResults).pipe(
      groupBy((studentResults: StudentResults) => studentResults.UserId), // Splits the dataset by studentResults.UserId
      mergeMap((group) => group.pipe(toArray())) // Using 'mergeMap' to consume 'GroupedObservables' (output by 'groupBy' operator) and outputting new observable dataset in an array.
    ).subscribe((studentDataSetEntry) => {
      this.calculateUserAverage(studentDataSetEntry); // Passes array of grouped each students data entries.
    })
  }

  private calculateUserAverage(studentDataSetEntry: Array<StudentResults>): void {
    let correctAnswers: number = 0;
    let totalQuestions: number = 0;
    let userId: number = 0;

    from(studentDataSetEntry).subscribe((studentDataSetEntry) => {
      if (studentDataSetEntry.Correct === 1) {
        correctAnswers += studentDataSetEntry.Correct;
        totalQuestions += 1;
      } else {
        totalQuestions += 1;
      }

      userId = studentDataSetEntry.UserId;
    })

    if (userId === 0) {
      return;
    }

    this.studentResultsSubject.next({ "UserId": userId, "Average": Math.round(correctAnswers / totalQuestions * 100) });
  }

  private orderBySubject(studentResults: Array<StudentResults>): void {
    from(studentResults).pipe(
      groupBy((studentResults: StudentResults) => studentResults.Subject),
      mergeMap((group) => group.pipe(toArray()))
    ).subscribe((studentDataSetEntry) => {
      this.calculateSubjectDifficulty(studentDataSetEntry);
    })
  }

  private calculateSubjectDifficulty(studentDataSetEntry: Array<StudentResults>): void {
    let subject: string = "";
    let subjectAverageDifficulty: number = 0;
    let totalQuestions: number = 0;

    from(studentDataSetEntry).subscribe((studentDataSetEntry) => {
      if (studentDataSetEntry.Difficulty === "0" || studentDataSetEntry.Difficulty === "NULL") { // One data entry contains a 'Difficulty = "NULL"' value.
        return;
      }

      subjectAverageDifficulty += +(studentDataSetEntry.Difficulty); // '+(' unary plus operator - attempts to covert to number if not already one.
      totalQuestions += 1;

      subject = studentDataSetEntry.Subject;
    });

    if (subject === "") {
      return;
    }

    this.subjectsSubject.next({ "Subject": subject, "Average": (subjectAverageDifficulty / totalQuestions) });
  }

  // Date Mutator
  private setDates(studentResults: Array<StudentResults>): void {
    from(studentResults).subscribe((studentDataSetEntry) => {
      let date = studentDataSetEntry.SubmitDateTime.split("T"); // Definitely a cleaner way of doing this.

      if (this.dates.includes(date[0])) {
        return;
      }

      this.dates.push(date[0]);
    })

    this.datesSubject.next(this.dates);
  }
  // END

  public getDayBreakdown(date: string): void {
    from(this.dataSet).pipe(
      groupBy((studentResults: StudentResults) => studentResults.SubmitDateTime.includes(date)),
      mergeMap((group) => group.pipe(toArray()))
    ).subscribe((studentDataSetEntry) => {
      this.setDayBreakdown(studentDataSetEntry, date);
    })
  }

  private setDayBreakdown(studentDataSetEntry: Array<StudentResults>, date: string): void {
    let begrijpendLezen: number = 0;
    let rekenen: number = 0;
    let spelling: number = 0;
    let subjectCount: number = 0;
    let dayBreakdown: Array<SubjectAverage> = [];

    from(studentDataSetEntry).subscribe((studentDataSetEntry) => {
      if (!studentDataSetEntry.SubmitDateTime.includes(date)) { // Discard other than the wanted date.
        return;
      }

      switch (studentDataSetEntry.Subject) {
        case "Begrijpend Lezen":
          begrijpendLezen++;
          subjectCount++;
          break;
        case "Rekenen":
          rekenen++;
          subjectCount++;
          break;
        case "Spelling":
          spelling++;
          subjectCount++;
          break;
        default:
          return;
      }
    });

    // Definitely a cleaner way of doing the below:
    if (begrijpendLezen > 0) {
      dayBreakdown.push({
        "Subject": "Begrijpend Lezen", "Average": Math.round(begrijpendLezen / subjectCount * 100),
      })
    }

    if (rekenen > 0) {
      dayBreakdown.push({
        "Subject": "Rekenen", "Average": Math.round(rekenen / subjectCount * 100),
      })
    }

    if (spelling > 0) {
      dayBreakdown.push({
        "Subject": "Spelling", "Average": Math.round(spelling / subjectCount * 100),
      })
    }

    if (begrijpendLezen === 0 && rekenen === 0 && spelling === 0) {
      return;
    }
    // END

    this.dayBreakdownSubject.next(dayBreakdown);
  }
}

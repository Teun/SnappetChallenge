import { Injectable } from '@angular/core';
import {OverviewService} from "@core/services/overview.service";
import {ApiStudent} from "@core/interfaces/api-student.interface";
import {BehaviorSubject, Observable, of} from "rxjs";
import {TableStudent} from "@overview/interfaces/table-student.interface";
import {ApiStudentsService} from "@core/services/api-students.service";
import {first, map, tap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  fetchedStudents$ = new BehaviorSubject<ApiStudent[]>([]);
  private _usersTable$ = new BehaviorSubject<TableStudent[]>([]);

  get usersTable$(): Observable<TableStudent[]> {
    return this._usersTable$.asObservable();
  }


  constructor(overviewService: OverviewService, private apiStudentsService: ApiStudentsService) {
    overviewService.filteredAnswers$.subscribe((answers) => {
      const students: TableStudent[] = this.fetchedStudents$.value.map(el => ({
        ...el,
        correctAnswers: 0,
        progress: 0
      }));
      answers.forEach((answer) => {
        const index = students.findIndex(el => el.id === answer.UserId)
        if (index !== -1){
          students[index] = {
            ...students[index],
            progress: students[index].progress + answer.Progress,
            correctAnswers: students[index].correctAnswers + answer.Correct
          }
        }
      })
      this._usersTable$.next(students);
    })
  }

  getStudents(): Observable<ApiStudent[]> {
    if (this.fetchedStudents$.value.length){
      return this.fetchedStudents$.pipe(first());
    }
    return this.apiStudentsService.getStudents()
      .pipe(tap((students) => {
        this.fetchedStudents$.next(students);
      }))
  }

  getStudent(id: number): Observable<ApiStudent | undefined> {
    if (this.fetchedStudents$.value.length){
      return of(this.fetchedStudents$.value.find(el => el.id === id)).pipe(first());
    }
    return this.apiStudentsService.getStudents()
      .pipe(
        map((students) => {
          this.fetchedStudents$.next(students);
          return students.find(el => el.id === id);
        }),
        first()
      );
  }
}

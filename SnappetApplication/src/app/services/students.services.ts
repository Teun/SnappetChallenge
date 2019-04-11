import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { groupBy, map, tap, filter } from 'rxjs/operators';
import * as _ from 'underscore';
import { ISummaryData, IResultV1Dto, IStudentV1Dto } from '../models/ISummaryData';
import { IDetailData } from '../models/IDetailData';
import { of, Observable } from 'rxjs';

@Injectable()
export class StudentsServices {

  private api = '/api/snappet/v1/students';
  private students: IStudentV1Dto[];

  constructor(private httpClient: HttpClient) {
  }

  getAllData(): Observable<IStudentV1Dto[]> {
    if (this.students) {
      return of(this.students);
    } else {
      return this.httpClient
        .get<IStudentV1Dto[]>(`${this.api}`)
        .pipe(
          map(data => this.students = data)
        );
    }
  }
}

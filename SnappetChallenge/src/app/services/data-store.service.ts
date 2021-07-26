import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ReplaySubject } from 'rxjs';
import { mergeMap, groupBy, reduce, toArray } from 'rxjs/operators';

import { StudentResults } from '../models/student-results.model';

@Injectable({
  providedIn: 'root'
})
export class DataStoreService {

  private studentResultsSubject = new ReplaySubject<StudentResults>(1);
  public studentResultsObservable = this.studentResultsSubject.asObservable();

  private strugglingStudentsSubject = new ReplaySubject<StudentResults>(1);
  public strugglingStudentsObservable = this.strugglingStudentsSubject.asObservable();

  private unratedStudentsSubject = new ReplaySubject<StudentResults>(1);
  public unratedStudentsObservable = this.unratedStudentsSubject.asObservable();

  // Would abstract this to an API layer.  
  constructor(
    private http: HttpClient,
  ) {
    this.http.get<StudentResults>("./assets/work.json").pipe(
      groupBy(response => response.UserId),
      mergeMap(response => response.pipe(toArray()))
    )
    .subscribe((response: any) => {
      // Mutators
      this.studentResultsObservable.next(response);
      this.strugglingStudentsObservable.next(response);
      this.unratedStudentsObservable.next(response);
      // End
    });
  }
}

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IDateRange } from '../models/date-range-model';
import { ISubjectStudentOverview } from '../models/subject-student-overview.model';

@Injectable({
  providedIn: 'root'
})
export class EducatorSubjectOverviewService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  get(subject: string, dateRange: IDateRange): Observable<ISubjectStudentOverview[]> {
    return this.http.get<ISubjectStudentOverview[]>(this.baseUrl + 'api/educatorsubjectoverview', {
      params: {
        subject: subject,
        startDateTimeUtc: dateRange.fromDate.toISOString(),
        endDateTimeUtc: dateRange.toDate.toISOString()
      }
    }).pipe(
      catchError(error => {
        console.error("An exception occurred retrieving the educator's subject overview: " + error);
        return throwError("An exception occurred retrieving the educator's subject overview.");
      }));
  }
}

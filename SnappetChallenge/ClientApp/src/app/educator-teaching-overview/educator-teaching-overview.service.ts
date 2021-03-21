import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ISubjectOverview } from '../models/subject-overview.model';

@Injectable({
  providedIn: 'root'
})
export class EducatorTeachingOverviewService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  get(startDate: Date, endDate: Date) : Observable<ISubjectOverview[]>  {
    return this.http.get<ISubjectOverview[]>(this.baseUrl + 'api/educatorteachingoverview', {
      params: {
        startDateTimeUtc: startDate.toISOString(),
        endDateTimeUtc: endDate.toISOString()
      }
    }).pipe(
      tap(data => console.log("educatorTeachingOverview: ", JSON.stringify(data)),
      catchError(error => {
        //TODO: Remove logging and improve error handling
        console.error(error);
        return throwError("An exception occurred retrieving the educator's teaching overview.");
      }))
    );
  }
}

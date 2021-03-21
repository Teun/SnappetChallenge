import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError, switchMap, tap } from 'rxjs/operators';
import { ISubjectOverviewDateRange } from '../models/subject-overview-date-range-model';
import { ISubjectOverview } from '../models/subject-overview.model';

@Injectable({
  providedIn: 'root'
})
export class EducatorTeachingOverviewService {
  defaultFromDate = new Date(2015, 2, 24);
  defaultToDate = new Date(2015, 2, 24, 12, 30);

  private dateRangeChangedSubject = new BehaviorSubject<ISubjectOverviewDateRange>({
    fromDate: this.defaultFromDate,
    toDate: this.defaultToDate
  });

  private dateRangeChangedAction$ = this.dateRangeChangedSubject.asObservable();

  // When the selected date range changes, call the API to retrieve the data.
  educatorTeachingOverview$ = this.dateRangeChangedAction$.pipe(
    switchMap(dateRange => this.http.get<ISubjectOverview[]>(this.baseUrl + 'api/educatorteachingoverview', {
      params: {
        startDateTimeUtc: dateRange.fromDate.toISOString(),
        endDateTimeUtc: dateRange.toDate.toISOString()
      }
    }).pipe(
      tap(data => console.log("educatorTeachingOverview: ", JSON.stringify(data)),
      catchError(error => {
        //TODO: Remove logging and improve error handling
        console.error(error);
        return throwError("An exception occurred retrieving the educator's teaching overview.");
      }))),
    )
  );

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  // Trigger the dateRangeChangedSubject which in turn calls the API to retrieve data.
  selectedDateRangeChanged(dateRange: ISubjectOverviewDateRange): void {
    this.dateRangeChangedSubject.next(dateRange);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkStatisticsByTopic } from '../model/work-statistics';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class WorkStatisticsService {
  constructor(private http: HttpClient) {}

  getWorkStatisticsByTopic(period: [Date, Date]): Observable<WorkStatisticsByTopic[]> {

    const from = moment(period[0]).startOf('day').toISOString();
    const to = moment(period[1]).endOf('day').toISOString();

    const url = `/api/reports/work?from=${from}&to=${to}`;

    return this.http.get<WorkStatisticsByTopic[]>(url);
  }
}

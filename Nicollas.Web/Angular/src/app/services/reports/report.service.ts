import { Injectable } from '@angular/core';
import { Api } from 'app/api.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ReportService {
  constructor(private api: Api) { }

  ReadApplyMonth(): Observable<Ngx.Charts.Single[]> {
    return this.api.get<Ngx.Charts.Single[]>('Reports/GetAplyMonth').publishLast().refCount();
  }

  ReadApplyWeek(): Observable<Ngx.Charts.Multiple[]> {
    return this.api.get<Ngx.Charts.Multiple[]>('Reports/GetAplyWeek').publishLast().refCount();
  }

  ReadDificultyWeek(): Observable<Ngx.Charts.Multiple[]> {
    return this.api.get<Ngx.Charts.Multiple[]>('Reports/GetDificultyWeek').publishLast().refCount();
  }

  ReadProgressWeek(): Observable<Ngx.Charts.Multiple[]> {
    return this.api.get<Ngx.Charts.Multiple[]>('Reports/GetProgressWeek').publishLast().refCount();
  }

}

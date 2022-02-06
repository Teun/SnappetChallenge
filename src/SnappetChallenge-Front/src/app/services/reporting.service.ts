import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { environment } from '../../environments/environment';
import { ProgressReportResultModel } from '../progress-report/progress-report-result.model';

@Injectable({
  providedIn: 'root'
})
export class ReportingService {

  constructor(
    private _httpClient: HttpClient
  ) { }

  public getProgressReport(): Observable<ProgressReportResultModel> {
    return this._httpClient.get<ProgressReportResultModel>(environment.api.baseUri + '/api/SubmittedAnswers/progress-report');
  }
}


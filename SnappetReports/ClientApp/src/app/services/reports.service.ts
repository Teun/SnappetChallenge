import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  _baseURL: string = "api/Reports";

  constructor(private http: HttpClient) { }

  GetReportJSON() {
    return this.http.get<ReportRecord[]>(this._baseURL + "/GetReportJSON");
  }

  GetSubjectAnswerCount() {
    return this.http.get<SubjectAnswerCount[]>(this._baseURL + "/GetSubjectAnswerCount");
  }

}

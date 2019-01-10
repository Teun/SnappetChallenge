import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class DatatableService {
  results = [];
  constructor(private http: HttpClient) {}
  apiURL = "/APIService";

  getData(date, subject, domain) {
    const headers: Headers = new Headers();
    headers.append("content-type", "application/json; charset=utf-8");
    return this.http.get(
      this.apiURL +
        "/Api/Work/GetReportByDateSubjectDomain?dateTime=" +
        date +
        "&domain=" +
        domain +
        "&subject=" +
        subject
    );
  }

  getAllSubjects() {
    const headers: Headers = new Headers();
    headers.append("content-type", "application/json; charset=utf-8");
    return this.http.get(this.apiURL + "/Api/Work/GetAllFilters");
  }

  getAllDomains() {
    return this.http.get(this.apiURL);
  }
}

export class SearchItem {
  SubmittedAnswerId: number;
  SubmitDateTime: Date;
  Correct: number;
  Progress: number;
  UserId: number;
  ExerciseId: number;
  Difficulty: string;
  Subject: string;
  Domain: string;
  LearningObjective: string;

  constructor(
    SubmittedAnswerId: number,
    SubmitDateTime: string,
    Correct: number,
    Progress: number,
    UserId: number,
    ExerciseId: number,
    Difficulty: string,
    Subject: string,
    Domain: string,
    LearningObjective: string
  ) {}
}

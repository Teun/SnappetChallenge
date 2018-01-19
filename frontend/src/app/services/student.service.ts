import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../../environments/environment';

@Injectable()
export class StudentService {

    constructor(private http: Http) { }

    getStudents(filterDate, subject, domain, rangeAccuracy) {

      if (subject === undefined) {
        subject = '-';
      }

      if (domain === undefined) {
        domain = '-';
      }

      if (rangeAccuracy === undefined) {
        rangeAccuracy = 100;
      }

      console.log(environment.backendUrl + environment.students(filterDate, subject, domain, rangeAccuracy));
      return this.http.get(
        environment.backendUrl + environment.students(filterDate, subject, domain, rangeAccuracy))
        .map((response) => response.json());
    }

    getSubjects() {
      return this.http.get(
        environment.backendUrl + environment.subjects)
        .map((response) => response.json());
    }

    getDomains(subject) {
      return this.http.get(
        environment.backendUrl + environment.domains(subject))
        .map((response) => response.json());
    }
}

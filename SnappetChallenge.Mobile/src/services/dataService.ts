import { Injectable } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

import { environment } from '../environments/environment';
import { CurrentDateService } from './currentDateService';
import { LearningObjective } from '../models/learningObjective';
import { StudentResult } from '../models/studentResult';

@Injectable()
export class DataService {

    constructor(private http: Http, private currentDateService: CurrentDateService) {
    }

    getLearningObjectives(): Observable<LearningObjective[]> {
        var params = this.getDateParameters();
        return this.http.get(environment.api + "learningobjectives", { search: params }).map(x => x.json());
    }

    getStudents(): Observable<number[]> {
        var params = this.getDateParameters();
        return this.http.get(environment.api + "students", { search: params }).map(x => x.json());
    }

    getStudentResults(studentId: number): Observable<StudentResult[]> {
        var params = this.getDateParameters();
        params.set('studentId', "" + studentId);
        return this.http.get(environment.api + "studentresults", { search: params }).map(x => x.json());
    }

    getDateParameters(): URLSearchParams {
        var params = new URLSearchParams();
        params.set('from', this.currentDateService.getFromDate());
        params.set('to', this.currentDateService.getToDate());
        return params;
    }
}
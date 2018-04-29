import { Component, Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ClassModel } from '../models/ClassModel';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http/src/static_response';

@Injectable()
export class WorkResultService {
    public classModel: ClassModel;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    getWorkResult(): Observable<Response> {        
        return this.http.get(this.baseUrl + 'api/assesments/work-results');
    }
}

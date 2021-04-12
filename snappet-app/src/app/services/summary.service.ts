import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Summary } from "../models/summary.model";
import { environment } from "src/environments/environment";


@Injectable()
export class SummaryService {

    constructor (private http: HttpClient) {
    }
    getSummary (date:string) {
        return this.http.get<Summary[]>( environment.apiEndPoint +'/summary/overview',{
            params:new HttpParams().set('date', date)
        });
    }
    getDomainSummary(date:string,subject:string) {
        return this.http.get<Summary[]>(environment.apiEndPoint + '/summary/domainsummary',{
            params:new HttpParams().set('date', String(date)).set('subject',subject)
        });
    }
    getLearningObjectivesSumary(date:string,domain:string) {
        return this.http.get<Summary[]>(environment.apiEndPoint + '/summary/learningobjectivesummary',{
            params:new HttpParams().set('date', String(date)).set('domain',domain)
        });
    }


}
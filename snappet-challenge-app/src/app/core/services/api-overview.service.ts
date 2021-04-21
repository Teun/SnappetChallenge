import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ApiAnswer} from "@core/interfaces/api-answer.interface";
import {environment} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ApiOverviewService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getOverview(): Observable<ApiAnswer[]> {
    return this.http.get<ApiAnswer[]>(this.baseUrl + '/overview');
  }


}

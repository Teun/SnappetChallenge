import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {ApiStudent} from "@shared/interfaces/api-student.interface";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ApiStudentsService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getStudents(): Observable<ApiStudent[]> {
    return this.http.get<ApiStudent[]>(this.baseUrl + '/students');
  }
}

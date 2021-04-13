import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Overview } from '../../model/overview';

@Injectable({
  providedIn: 'root'
})
export class ClassOverviewService {

  constructor(private http: HttpClient) { }

  fetchResults(): Observable<Overview[]>{
    const url = 'http://localhost:3000/rawData';
    return this.http.get<Overview[]>(`${url}`);
  }
}

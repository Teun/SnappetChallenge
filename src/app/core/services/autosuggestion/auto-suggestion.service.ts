import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Suggestion } from '../../model/suggestion';

@Injectable({
  providedIn: 'root'
})
export class AutoSuggestionService {
  constructor(private http: HttpClient) { }

  fetchResults(value: string): Observable<Suggestion[]>{
    const url = 'http://localhost:3000/suggestions';
    return this.http.get<Suggestion[]>(`${url}?filter=${value}`);
  }
}

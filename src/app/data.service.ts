import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Observable } from "rxjs";
import { Data } from './data';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor(private http: HttpClient) { }

  public getData(): Observable<Data[]> {
    return this.http.get<Data[]>('https://raw.githubusercontent.com/Snappet/SnappetChallenge/master/Data/work.json');
  }
}

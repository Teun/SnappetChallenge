import { Injectable } from '@angular/core';
import { Http, Headers } from "@angular/http";
import { Observable } from "rxjs";
import 'rxjs/add/operator/map';

import { UserDto } from "app/dtos/user-dto";

@Injectable()
export class WorkResultService {

  private headers: Headers;

  constructor(
    private http: Http
  ) {
    this.headers = new Headers({
      "Accept": "application/json",
      "Content-Type": "application/json"
    });
  }

  public GetTodaysData(): Observable<UserDto[]> {
    return this.http.get(this.GetUrl(), { headers: this.headers })
      .map(response => response.status === 200 ? response.json().map(item => new UserDto(item)) : null);
  }

  private GetUrl(): string {
    // normally we would construct the string here based on the current time, 
    // this is something omitted for this excercise.
    return "http://localhost:5000/api/WorkResults?startTimeUtc=2015-03-24&endTimeUtc=2015-03-24T11:30:00";
  }
}

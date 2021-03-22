import {Injectable} from '@angular/core';
import {HttpClient, HttpEventType, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError, last, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BaseHttpService {

  constructor(private http: HttpClient) {

  }

  get(url): Observable<any> {
    return this.http.get(url).pipe(
      map(this.mapResponse),
      last(),
      catchError(async (error) => console.log(error))
    );
  }

  post(url, data): Observable<any> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post(url, data, {
      headers: headers
    }).pipe(
      map(this.mapResponse),
      last(),
      catchError(async (error) => console.log(error))
    );
  }

  mapResponse(event): void {
    return event.data;
  }
}

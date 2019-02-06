import { Injectable } from "@angular/core";
import { Observable, of, throwError } from "rxjs";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";
import { catchError, tap, map } from "rxjs/operators";
import { PubilDailyInsight } from "../models/pubil-daily-insight";
import { DailySubmittedAnswersPerSubjectInsight } from "../models/daily-submitted-answers-per-subject-insight";

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" })
};
const apiUrl = "https://localhost:44359/api/insights";

@Injectable({
  providedIn: "root"
})
export class InsightsService {
  constructor(private http: HttpClient) {}

  getPubilsDailyInisghts(day:Date): Observable<PubilDailyInsight[]> {
    return this.http.get<PubilDailyInsight[]>(apiUrl+'/pubilsDaily/'+day).pipe(
      tap(products => console.log("getting getPubilsDailyInisghts")),
      catchError(this.handleError("getPubilsDailyInisghts", []))
    );
  }
  private handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}

import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {ResultsModel} from "../models/results.model";

@Injectable({
  providedIn: 'root'
})
export class ResultService {

  constructor(private http: HttpClient) {
  }

  public getResults(): Observable<Array<ResultsModel>> {
    return this.http.get<Array<ResultsModel>>(`${environment.apiBaseUrl}/api/results`);
  }
}

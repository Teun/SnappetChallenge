import {Injectable} from "@angular/core";
import {shareReplay} from "rxjs/operators";
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user";

@Injectable({
  providedIn: 'root',
})
export class UserService {
  readonly users$ = this.http.get<User[]>('http://localhost:8988/users').pipe(
    shareReplay(1),
  );

  constructor(
    private http: HttpClient,
  ) {
  }

}

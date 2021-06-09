import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user";

@Injectable({
  providedIn: 'root',
})
export class UserService {
  getUsers() {
    return this.http.get<User[]>('http://localhost:8988/users');
  }

  constructor(
    private http: HttpClient,
  ) {
  }
}

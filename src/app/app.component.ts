import {Component} from "@angular/core";
import {UserService} from "./services/user.service";
import {catchError} from "rxjs/operators";
import {throwError} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  public showError = false;
  public links = [
    {
      title: 'Answers',
      url: 'answers',
    },
    {
      title: 'Statistics',
      url: 'statistics',
    },
  ];

  readonly errors = this.userService.users$.pipe(
    catchError(e => {
      this.showError = true;
      return throwError(e);
    })
  ).subscribe();

  constructor(public userService: UserService) {
  }
}

import {Component} from "@angular/core";
import {Store} from "@ngrx/store";
import {loadUsers} from "./ngrx/answers.actions";
import {State} from "./interfaces/state";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  public showError$ = this.store.select(state => state.answers.serverUnavailable);
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

  constructor(private store: Store<State>) {
  }

  ngOnInit() {
    this.store.dispatch(loadUsers());
  }
}

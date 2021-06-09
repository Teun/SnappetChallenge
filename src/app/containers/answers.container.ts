import {Component} from "@angular/core";
import {selectVisibleRows} from "../ngrx/answers.reducer";
import {Store} from "@ngrx/store";
import {State} from "../interfaces/state";

@Component({
  selector: 'app-answers-container',
  template: `
    <app-answers
      [rows]="visibleRows$ | async"
    ></app-answers>
  `,
})
export class AnswersContainer {
  readonly visibleRows$ = this.store.select(selectVisibleRows);

  constructor(private store: Store<State>) {}
}

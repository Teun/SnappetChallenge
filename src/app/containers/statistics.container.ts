import {Component} from "@angular/core";
import {selectTotalAnswers, selectTotalStudents} from "../ngrx/answers.reducer";
import {Store} from "@ngrx/store";
import {State} from "../interfaces/state";

@Component({
  selector: 'app-statistics-container',
  template: `
    <app-statistics
      [students]="students$ | async"
      [answers]="answers$ | async"
    ></app-statistics>
  `,
})
export class StatisticsContainer {
  readonly students$ = this.store.select(selectTotalStudents);
  readonly answers$ = this.store.select(selectTotalAnswers);

  constructor(private store: Store<State>) {}
}

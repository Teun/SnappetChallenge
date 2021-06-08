import {Component} from "@angular/core";
import {AnswersTableService} from "../services/answers-table.service";

@Component({
  selector: 'app-statistics-container',
  template: `
    <app-statistics
      [students]="answersTableService.students$ | async"
      [answers]="answersTableService.answers$ | async"
    ></app-statistics>
  `,
})
export class StatisticsContainer {
  constructor(
    public answersTableService: AnswersTableService
  ) {
  }
}

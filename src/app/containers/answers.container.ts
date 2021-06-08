import {Component} from "@angular/core";
import {LearningObjectiveService} from "../services/learning-objective.service";
import {ControlsService} from "../services/controls.service";
import {AnswersTableService} from "../services/answers-table.service";

@Component({
  selector: 'app-answers-container',
  template: `
    <app-answers
      [rows]="answersTableService.visibleRows$ | async"
    ></app-answers>
  `,
})
export class AnswersContainer {
  constructor(
    public answersTableService: AnswersTableService,
    public learningObjectivesService: LearningObjectiveService,
    public controlsService: ControlsService,
  ) {
  }
}

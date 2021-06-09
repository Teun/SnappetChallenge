import {Component} from "@angular/core";
import {MatSelectChange} from "@angular/material/select";
import {AnswersState} from "../../ngrx/answers.reducer";
import {Store} from "@ngrx/store";
import {changeLearningObjective} from "../../ngrx/answers.actions";
import {allLearningObjectives} from "src/app/models/answer";
import {State} from "../../interfaces/state";

@Component({
  selector: 'app-learning-objective',
  templateUrl: './learning-objective.component.html',
  styleUrls: ['./learning-objective.component.css'],
})
export class LearningObjectiveComponent {
  readonly allLearningObjectives = allLearningObjectives;
  readonly learningObjective = this.store.select(state => state.answers.learningObjective);
  readonly learningObjectives = this.store.select(state => state.answers.learningObjectives);

  constructor(public store: Store<State>) {
  }

  onObjectiveChange($event: MatSelectChange) {
    this.store.dispatch(changeLearningObjective({ learningObjective: $event.value }));
  }
}

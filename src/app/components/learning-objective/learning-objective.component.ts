import {Component} from "@angular/core";
import {LearningObjectiveService} from "../../services/learning-objective.service";
import {MatSelectChange} from "@angular/material/select";

@Component({
  selector: 'app-learning-objective',
  templateUrl: './learning-objective.component.html',
  styleUrls: ['./learning-objective.component.css'],
})
export class LearningObjectiveComponent {
  constructor(public learningObjectiveService: LearningObjectiveService) {
  }

  onObjectiveChange($event: MatSelectChange) {
    this.learningObjectiveService.learningObjective.next($event.value);
  }
}

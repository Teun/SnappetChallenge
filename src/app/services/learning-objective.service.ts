import {Injectable} from "@angular/core";
import {BehaviorSubject, Observable} from "rxjs";
import {allLearningObjectives, Answer, LearningObjective} from "../models/answer";
import {filter, map, scan} from "rxjs/operators";
import {AnswersService} from "./answers.service";

@Injectable({
  providedIn: 'root',
})
export class LearningObjectiveService {
  readonly allLearningObjectives = allLearningObjectives;
  public learningObjective = new BehaviorSubject<LearningObjective>(allLearningObjectives);

  readonly learningObjectives$: Observable<LearningObjective[]> = this.answersService.answer$.pipe(
    scan((acc: Set<LearningObjective>, answer: Answer) => {
      acc.add(answer.LearningObjective);
      return acc;
    }, new Set()),
    map(answers => Array.from(answers))
  );

  constructor(public answersService: AnswersService) {
  }
}

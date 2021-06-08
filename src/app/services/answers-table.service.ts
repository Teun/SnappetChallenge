import {Injectable} from "@angular/core";
import {allLearningObjectives, Answer, UserId} from "../models/answer";
import {filter, map, publish, scan, shareReplay, switchMap} from "rxjs/operators";
import {combineLatest, merge} from "rxjs";
import {Row, TableAnswer} from "../components/answers/answers.component";
import {ControlsService, ControlsState} from "./controls.service";
import {LearningObjectiveService} from "./learning-objective.service";
import {AnswersService} from "./answers.service";
import {UserService} from "./user.service";

type Acc = { [key: string]: { users: Set<UserId>, answers: number } };

@Injectable({
  providedIn: 'root',
})
export class AnswersTableService {
  readonly rows$ = merge(
    this.answersService.answer$,
    this.controlsService.state,
  )
    .pipe(
      switchMap(() => combineLatest(this.answersService.answer$, this.userService.users$)),
      scan((acc: Row[], [answer, users]) => {
        if (this.controlsService.state.value === ControlsState.Stop) {
          return [];
        }
        const user = users.find(user => user.id === answer.UserId);
        const userName = user && user.name || answer.UserId;

        const student = acc.find(row => row.userId === answer.UserId);
        if (student == null) {
          acc.push({
            userId: answer.UserId,
            userName: String(userName),
            answers: [{
              correct: answer.Correct,
              learningObjective: answer.LearningObjective,
            }],
          })
        } else {
          student.answers.push({
            correct: answer.Correct,
            learningObjective: answer.LearningObjective,
          });
        }

        return acc.slice();
      }, []),
      shareReplay(1),
    );

  readonly visibleRows$ = merge(
    this.rows$,
    this.learningObjectiveService.learningObjective,
    this.controlsService.state,
  ).pipe(
    switchMap(() => this.rows$),
    map(rows => {
      const learningObjective = this.learningObjectiveService.learningObjective.value;
      return rows.map(row => {
        return {
          ...row,
          answers: row.answers.filter((answer: TableAnswer) => {
            return (
              answer.learningObjective === learningObjective ||
              learningObjective === allLearningObjectives
            );
          })
        }
      });
    }),
    filter(() => this.controlsService.state.value !== ControlsState.Pause),
    shareReplay(1),
  );

  readonly statistics$ = merge(
    this.answersService.answer$,
    this.controlsService.state,
  )
    .pipe(
      switchMap(() => this.answersService.answer$),
      scan((acc: Acc, answer: Answer) => {
        const objective = answer.LearningObjective;

        if (this.controlsService.state.value === ControlsState.Stop) {
          return { [allLearningObjectives]: { users: new Set(), answers: 0 } } as Acc;
        }

        acc[allLearningObjectives].users.add(answer.UserId);
        acc[allLearningObjectives].answers++;

        if (objective in acc) {
          acc[objective].users.add(answer.UserId);
          acc[objective].answers++;
        } else {
          acc[objective] = {
            users: new Set([answer.UserId]),
            answers: 1,
          };
        }

        return acc;
      }, { [allLearningObjectives]: { users: new Set(), answers: 0 } } as Acc),
      shareReplay(1),
    );

  readonly students$ = this.statistics$.pipe(
    map(statistics => {
      const stats = statistics[this.learningObjectiveService.learningObjective.value];
      if (stats == null) {
        return 0;
      }
      return stats.users.size || 0
    }),
    filter(() => this.controlsService.state.value !== ControlsState.Pause),
    shareReplay(1)
  );

  readonly answers$ = this.statistics$.pipe(
    map(statistics => {
      const stats = statistics[this.learningObjectiveService.learningObjective.value];
      if (stats == null) {
        return 0;
      }
      return stats.answers || 0
    }),
    filter(() => this.controlsService.state.value !== ControlsState.Pause),
    shareReplay(1)
  );

  constructor(
    private answersService: AnswersService,
    private learningObjectiveService: LearningObjectiveService,
    private controlsService: ControlsService,
    private userService: UserService,
  ) {
    this.answers$.subscribe();
    this.visibleRows$.subscribe();
    this.students$.subscribe();
  }
}

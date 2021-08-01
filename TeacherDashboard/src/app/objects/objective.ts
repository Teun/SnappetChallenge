import { Answer } from '../interfaces/answer';
import { average } from '../utils/average';
import { Excercise } from './excercise';

export class Objective {
  public excercises: Array<Excercise> = [];

  constructor(public objective: string) { }

  public static fromAnswer(answer: Answer): Objective {
    return new Objective(answer.LearningObjective);
  }

  public addAnswer(answer: Answer): void {
    let excercise = this.excercises.find(item => item.id === answer.ExerciseId)

    if (!excercise) {
      excercise = Excercise.fromAnswer(answer);
      this.excercises.push(excercise)
    }

    excercise.addAnswer(answer);
  }

  public get answerCount(): number {
    return this.excercises.reduce((accumulator, item) => accumulator + item.answerCount, 0)
  }

  public get progress(): number {
    return average(this.excercises.map(item => item.progress));
  }

  public sort(): void {
    this.excercises.sort((a, b) => b.answerCount - a.answerCount);
  }
}

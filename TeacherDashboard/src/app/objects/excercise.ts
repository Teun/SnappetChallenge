import { Answer } from '../interfaces/answer';
import { average } from '../utils/average';

export class Excercise {
  public answers: Array<Answer> = [];

  constructor(
    public id: number,
    private _difficulty: string,
    public subject: string,
    public objective: string
  ) { }

  public static fromAnswer(answer: Answer): Excercise {
    return new Excercise(answer.ExerciseId, answer.Difficulty, answer.Subject, answer.LearningObjective)
  }

  public addAnswer(answer: Answer): void {
    this.answers.push(answer);
  }

  public get answerCount(): number {
    return this.answers.length;
  }

  public get difficulty(): string {
    return Number.isNaN(Number.parseFloat(this._difficulty)) ? "" : this._difficulty;
  }

  public get progress(): number {
    const items = this.answers
      .map(item => item.Progress)
      .filter(item => item != 0)

    return average(items);
  }
}

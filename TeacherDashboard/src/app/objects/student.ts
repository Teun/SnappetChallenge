import { Answer } from '../interfaces/answer';
import { average } from '../utils/average';
import { SubjectGroup } from './subject-group';

export class Student {
  private _groups: Array<SubjectGroup> = [];

  constructor(public id: number) { }

  public static fromAnswer(answer: Answer): Student {
    return new Student(answer.UserId);
  }

  public addAnswer(answer: Answer): void {
    let group = this._groups.find(item => item.subject === answer.Subject);

    if (!group) {
      group = SubjectGroup.fromAnswer(answer);
      this._groups.push(group);
    }

    group.addAnswer(answer);
  }

  public get groups(): Array<SubjectGroup> {
    this._groups.forEach(group => group.sort())
    this._groups.sort((a, b) => b.answerCount - a.answerCount);

    return this._groups;
  }

  public get answerCount(): number {
    return this._groups.reduce((accumulator, item) => accumulator + item.answerCount, 0)
  }

  public get progress(): number {
    return average(this._groups.map(item => item.progress));
  }

  public sort(): void {
    this._groups.sort((a, b) => b.answerCount - a.answerCount);
  }
}

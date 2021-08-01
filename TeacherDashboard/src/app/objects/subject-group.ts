import { Answer } from '../interfaces/answer';
import { average } from '../utils/average';
import { Objective } from './objective';

export class SubjectGroup {
  public objectives: Array<Objective> = [];

  constructor(public subject: string) { }

  public static fromAnswer(answer: Answer): SubjectGroup {
    return new SubjectGroup(answer.Subject);
  }

  public addAnswer(answer: Answer): void {
    let objective = this.objectives.find(item => item.objective === answer.LearningObjective)

    if (!objective) {
      objective = Objective.fromAnswer(answer);
      this.objectives.push(objective)
    }

    objective.addAnswer(answer);
  }

  public get answerCount(): number {
    return this.objectives.reduce((accumulator, item) => accumulator + item.answerCount, 0)
  }

  public get progress(): number {
    return average(this.objectives.map(item => item.progress));
  }

  public sort(): void {
    this.objectives.forEach(objective => objective.sort())
    this.objectives.sort((a, b) => b.answerCount - a.answerCount);
  }
}

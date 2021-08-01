import { Answer } from '../interfaces/answer';
import { Student } from './student';
import { SubjectGroup } from './subject-group';

export class DataHolder {
  private _groups: Array<SubjectGroup> = [];
  private _students: Array<Student> = [];

  public addAnswer(answer: Answer): DataHolder {
    this.addAnswerToGroup(answer);
    this.addAnswerToStudent(answer);

    return this;
  }

  private addAnswerToGroup(answer: Answer): void {
    let group = this._groups.find(item => item.subject === answer.Subject);

    if (!group) {
      group = SubjectGroup.fromAnswer(answer);
      this._groups.push(group);
    }

    group.addAnswer(answer);
  }

  private addAnswerToStudent(answer: Answer): void {
    let student = this._students.find(item => item.id === answer.UserId);

    if (!student) {
      student = Student.fromAnswer(answer);
      this._students.push(student);
    }

    student.addAnswer(answer);
  }

  public get groups(): Array<SubjectGroup> {
    this._groups.forEach(group => group.sort())
    this._groups.sort((a, b) => b.answerCount - a.answerCount);

    return this._groups;
  }

  public get students(): Array<Student> {
    this._students.forEach(student => student.sort())
    this._students.sort((a, b) => b.answerCount - a.answerCount);

    return this._students;
  }
}

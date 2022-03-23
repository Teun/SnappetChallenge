import { Injectable } from '@angular/core';
import workData from './work.json';
import { WorkReport } from "./dashboard";
import {isSameDay} from "./date-utils";

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private workData: WorkReport[] = workData;
  public currentDate = new Date('2015-03-24T11:30:00Z');

  constructor() { }

  getDataForDay(day: Date, isToday = false) {

    return this.workData.filter(report => {
      const reportDate = new Date(report.SubmitDateTime);

      if (!isToday) {
        return isSameDay(day, reportDate)
      }

      return isSameDay(day, reportDate) && this.currentDate > reportDate;
    });
  }

  getStudents(workData: any[]) {
    return workData
        .map(report => {
          return report.UserId;
        })
        .filter((id, idx, arr) => idx === arr.indexOf(id));
  }

  getReport(day: Date, isToday = false) {
    const workData = this.getDataForDay(day, isToday);

    const students = this.getStudents(workData);

    const correctEntries = this.calculateCorrectEntries(workData);

    return {
      submittedEntries: workData.length,
      correctEntries,
      successRate: correctEntries / workData.length,
      studentNumber: students.length,
    }
  }

  calculateCorrectEntries(workData: WorkReport[]): number {
    return workData.filter(({Correct}) => !!Correct).length;
  }

  getStudentsWithResults(day: Date) {
    const workData = this.getDataForDay(day);

    const students = this.getStudents(workData);

    return students.map(student => {
      const answers = workData
          .filter(answer => answer.UserId === student)
          .reduce((result, answer) => {
            result.total += 1;

            result.correct += answer.Correct;

            return result;
          }, {total: 0, correct: 0});

      return {
        id: student,
        answers
      }
    })
  }

  getMonthData() {
    const submittedEntries = this.workData.length;
    const correctEntries = this.workData.reduce((total, entry) => {
      return total + entry.Correct;
    }, 0);
    const successRate = correctEntries / submittedEntries;

    return {
      submittedEntries,
      correctEntries,
      successRate,
    }
  }

  getAllStudents() {
    return this.workData
        .map(report => {
          return report.UserId;
        })
        .filter((id, idx, arr) => idx === arr.indexOf(id));
  }

  getStudent(id: number) {
    const studentResults = this.workData
        .filter(task => task.UserId === id);

    const subjects = studentResults
        .map(task => {
          return task.Subject;
        })
        .filter((id, idx, arr) => idx === arr.indexOf(id));

    const subjectSplit: any = {};
    const subjectProgress: any = {};
    const subjectSuccessRate: any = {};

    subjects.forEach(subject => {
      subjectSplit[subject] = 0;

      const subjectTasks = studentResults.filter(result => result.Subject === subject);

      subjectProgress[subject] = subjectTasks
          .map((result) => result.Progress);


      subjectSuccessRate[subject] = subjectTasks
          .filter(result => result.Correct).length / subjectTasks.length;
    });

    studentResults.forEach(task => {
      subjectSplit[task.Subject] += 1;
    });

    return {
      subjectSplit,
      subjectProgress,
      subjectSuccessRate,
    };
  }
}

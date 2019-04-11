import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { groupBy, map, tap, filter } from 'rxjs/operators';
import * as _ from 'underscore';
import { ISummaryData, IResultV1Dto, IStudentV1Dto } from '../models/ISummaryData';
import { IDetailData } from '../models//IDetailData';
import { StudentsServices } from '../services/students.services';
import { forkJoin, of } from 'rxjs';
import { ResultsServices } from '../services/results.services';

@Injectable()
export class StudentSummaryServices {

  constructor(private httpClient: HttpClient, private resultServices: ResultsServices, private studentServices: StudentsServices) {
  }

  getSummary() {
    return forkJoin(this.studentServices.getAllData(), this.resultServices.getAllData())
      .pipe(
        map(([students, results]) => {
          console.log(students);

          const summaryData: ISummaryData[] = [];
          const groupedData = _.groupBy<IResultV1Dto>(results, item => item.userId);

          _.each(groupedData, (groupItem, key) => {
            const attempted = groupItem.length;

            const correct = _.reduce(groupItem, (sum, item) => {
              return item.correct > 0 ? sum + 1 : sum;
            }, 0);

            const inCorrect = _.reduce(groupItem, (sum, item) => {
              return item.correct === 0 ? sum + 1 : sum;
            }, 0);

            const student = _.find<IStudentV1Dto>(students, (item) => item.studentId === Number(key));
            summaryData.push({ id: key, name: student.name, attempted, correct, incorrect: inCorrect });

          });

          return summaryData;
        })
      );
  }
}

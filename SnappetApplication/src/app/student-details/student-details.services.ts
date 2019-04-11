import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { groupBy, map, tap, filter } from 'rxjs/operators';
import * as _ from 'underscore';
import { ISummaryData, IResultV1Dto, IStudentV1Dto } from '../models/ISummaryData';
import { IDetailData } from '../models/IDetailData';
import { StudentsServices } from '../services/students.services';
import { forkJoin, of } from 'rxjs';

@Injectable()
export class StudentDetailsServices {

  constructor(private httpClient: HttpClient, private studentServices: StudentsServices) {
  }

  getDetails(userId: string) {
    return this.studentServices.getAllData()
      .pipe(
        map(data => {
          const summaryData: ISummaryData[] = [];
          const filterData = _.filter(data, (item) => {
            return item.userId == userId;
          });

          const detailDataFn = () => {
            const groupedData = _.groupBy(data, item => item.subject);
            const detailData: IDetailData[] = [];
            _.each(groupedData, (value, key) => {
              const attempted = value.length;
              const correct = _.reduce(value, (sum, item) => {
                return item.correct > 0 ? sum + 1 : sum;
              }, 0);

              const inCorrect = _.reduce(value, (sum, item) => {
                return item.correct === 0 ? sum + 1 : sum;
              }, 0);

              detailData.push({ subject: key, attempted, correct, incorrect: inCorrect });
            });

            return detailData;
          };

          const studentDetailData = {
            fullData: filterData,
            detailData: detailDataFn()
          };

          return studentDetailData;
        })
      );
  }
}

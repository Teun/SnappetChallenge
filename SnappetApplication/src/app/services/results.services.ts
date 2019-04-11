import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { groupBy, map, tap, filter } from 'rxjs/operators';
import * as _ from 'underscore';
import { ISummaryData, IResultV1Dto, IStudentV1Dto } from '../models/ISummaryData';
import { IDetailData } from '../models/IDetailData';
import { StudentsServices } from './students.services';
import { forkJoin, of } from 'rxjs';

@Injectable()
export class ResultsServices {

  private api = '/api/snappet/v1/results';

  private fullData: IResultV1Dto[];

  constructor(private httpClient: HttpClient, private studentServices: StudentsServices) {
  }

  public getAllData() {
    if (this.fullData) {
      return of(this.fullData);
    } else {
      return this.httpClient
        .get<IResultV1Dto[]>(`${this.api}?dateTime=2015-03-24`)
        .pipe(
          map(data => this.fullData = data)
        );
    }
  }

  getDetails(userId: string) {
    return this.httpClient
      .get<IResultV1Dto[]>(`${this.api}?dateTime=2015-03-24`)
      .pipe(
        map(data => {
          this.fullData = data;
          const summaryData: ISummaryData[] = [];
          const filterData = _.filter(this.fullData, (item) => {
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

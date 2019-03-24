import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { groupBy, map, tap, filter } from 'rxjs/operators';
import * as _ from 'underscore';
import { ISummaryData } from './ISummaryData';
import { IDetailData } from './IDetailData';

@Injectable()
export class ClassDataServices {

  private api = "http://localhost:4071/api/snappet/v1/results";

  private fullData: any;

  constructor(private httpClient: HttpClient) {
  }

  getAllData() {
    return this.httpClient
      .get(`${this.api}?dateTime=2015-03-24`)
      .pipe(
        map(data => {
          this.fullData = data;
          const summaryData: ISummaryData[] = [];
          const groupedData = _.groupBy(data, item => item.userId);

          _.each(groupedData, (groupItem, key) => {
            const attempted = groupItem.length;

            const correct = _.reduce(groupItem, (sum, item) => {
              return item.correct > 0 ? sum + 1 : sum;
            }, 0);

            const inCorrect = _.reduce(groupItem, (sum, item) => {
              return item.correct === 0 ? sum + 1 : sum;
            }, 0);

            summaryData.push({ name: key, attempted, correct, incorrect: inCorrect });
            // summaryData.push()
          });

          return summaryData;
        })
      );
  }

  getDetails(userId: string) {
    return this.httpClient
      .get(`${this.api}?dateTime=2015-03-24`)
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
            fullData : filterData,
            detailData : detailDataFn()
          };

          return studentDetailData;
        })
      );
  }
}

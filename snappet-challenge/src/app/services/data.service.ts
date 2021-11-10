import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { withLatestFrom, map, publishReplay, refCount } from 'rxjs/operators';
import WORK_DATA from '../../assets/work.json';
import { ProcessedWorkData, Work } from '../types/work';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  // Stores the date for which work data should be displayed
  private currentDate$ = new BehaviorSubject('2015-03-24');

  // Data source
  private data$ = of(WORK_DATA as Work[]).pipe(
    withLatestFrom(this.currentDate$),
    map(([data, date]) => {
      return data.filter((item) => item.SubmitDateTime.startsWith(date));
    })
  );

  // Date exposed as readonly for UI
  selectedDate$ = this.currentDate$
    .asObservable()
    .pipe(map((dateStr) => new Date(dateStr)));

  // Transforming data to a consumable format - refer types/work.ts for data format
  processedData$ = this.data$.pipe(
    map((data) => {
      let subjects: ProcessedWorkData = {};
      data.forEach((item) => {
        if (subjects[item.Subject]) {
          if (subjects[item.Subject].domains[item.Domain]) {
            if (
              subjects[item.Subject].domains[item.Domain].objectives[
                item.LearningObjective
              ]
            ) {
              subjects[item.Subject].count++;
              subjects[item.Subject].domains[item.Domain].count++;
              subjects[item.Subject].domains[item.Domain].objectives[
                item.LearningObjective
              ].count++;
            } else {
              subjects[item.Subject].count++;
              subjects[item.Subject].domains[item.Domain].count++;
              subjects[item.Subject].domains[item.Domain].objectives[
                item.LearningObjective
              ] = {
                count: 1,
              };
            }
          } else {
            subjects[item.Subject].count++;
            subjects[item.Subject].domains[item.Domain] = {
              count: 1,
              objectives: {
                [item.LearningObjective]: { count: 1 },
              },
            };
          }
        } else {
          subjects[item.Subject] = {
            count: 1,
            domains: {
              [item.Domain]: {
                count: 1,
                objectives: {
                  [item.LearningObjective]: {
                    count: 1,
                  },
                },
              },
            },
          };
        }
      });

      return subjects;
    }),
    publishReplay(1),
    refCount()
  );
}

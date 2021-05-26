import {Component, OnDestroy} from "@angular/core";
import {DataService} from "./data.service";
import {Data, SubmitDate, UserId} from "./data";
import {unique} from "./utils";
import {distinctUntilChanged, map, shareReplay, switchMap, tap} from "rxjs/operators";
import {MAT_MOMENT_DATE_ADAPTER_OPTIONS} from "@angular/material-moment-adapter";
import {MatDatepickerInputEvent} from "@angular/material/datepicker";
import {BehaviorSubject, merge} from "rxjs";
import * as moment from "moment/moment";
import {Moment} from "moment";
import {MatSelectChange} from "@angular/material/select";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {useUtc: true, strict: true}},
  ]
})
export class AppComponent implements OnDestroy {
  readonly allStudentsId = -1;

  public data = this.dataService.getData().pipe(shareReplay(1));
  public date = new BehaviorSubject(moment(Date.UTC(2015, 2, 24)));
  public student = new BehaviorSubject<UserId>(this.allStudentsId);
  public filteredData = new BehaviorSubject<Data[]>([]);

  public updateFilteredDataSubscription = merge(
    this.data,
    this.date,
    this.student.pipe(distinctUntilChanged()),
  ).pipe(
    tap(() => this.filteredData.next([])),
    switchMap(_ => this.data),
    map(data => {
      return data
        .filter(d => SubmitDate(d) === this.selectedDate)
        .filter(d => this.student.value == this.allStudentsId || this.student.value === d.UserId)
    }),
    tap(data => this.filteredData.next(data)),
  ).subscribe();

  public students = this.data.pipe(
    map(filteredData => {
      const userIds = filteredData.map(d => d.UserId);
      return unique(userIds)
    }),
  );

  public subjectData = this.filteredData.pipe(
    map(data => {
      const counts = data.reduce((acc, { Subject }) => {
        return {
          ...acc,
          [Subject]: (acc[Subject] || 0) + 1,
        };
      }, {} as { [name: string]: number });

      return Object.keys(counts).reduce((acc, key) => {
        return [
          ...acc,
          {
            name: key,
            value: counts[key],
          },
        ];
      }, [] as { name: string, value: number }[]);
    })
  );

  public cumulativeProgressBySubject = this.filteredData.pipe(
    map(data => {
      const counts = data.reduce((acc, { Subject, Progress }) => {
        return {
          ...acc,
          [Subject]: (acc[Subject] || 0) + Progress,
        };
      }, {} as { [name: string]: number });

      return Object.keys(counts).reduce((acc, key) => {
        return [
          ...acc,
          {
            name: key,
            value: counts[key],
          },
        ];
      }, [] as { name: string, value: number }[]);
    })
  );

  private get selectedDate(): string {
    const year = String(this.date.value.year());
    const month = String(this.date.value.month() + 1).padStart(2, '0');
    const day = String(this.date.value.date()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  constructor(private dataService: DataService) {
  }

  public onDateChange(event: MatDatepickerInputEvent<unknown>) {
    this.date.next(event.value as Moment);
  }

  public onStudentChange(event: MatSelectChange) {
    this.student.next(event.value);
  }

  public ngOnDestroy() {
    this.updateFilteredDataSubscription.unsubscribe();
  }
}

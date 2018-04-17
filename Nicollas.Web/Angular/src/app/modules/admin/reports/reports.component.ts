import { Component, OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { single, multi } from './data';
import { Store } from '@ngrx/store';

import * as fromRoot from 'app/store/reducers';
import * as fromReports from 'app/store/reducers/reports';
import { MdDialog } from '@angular/material';
import * as Action from 'app/store/actions/reports/report.action';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {
  IsBusy: Observable<number>;


  applyMonth: Observable<Ngx.Charts.Single[]>;
  applyWeek: Observable<Ngx.Charts.Multiple[]>;
  dificultyByDay: Observable<Ngx.Charts.Multiple[]>;
  progressByDay: Observable<Ngx.Charts.Multiple[]>;

  dificultyByStudantByDay: Observable<Ngx.Charts.Multiple[]>;
  progressByStudantByDay: Observable<Ngx.Charts.Multiple[]>;

  view: any[] = [700, 400];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Domains';
  showYAxisLabel = true;
  yAxisLabel = 'Quantity of applies';

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA', '#1569ef', '#9108cc']
  };

  studantId = 40267;

  studantList = [
    40267,
    40268,
    40270,
    40271,
    40272,
    40273,
    40274,
    40275,
    40276,
    40277,
    40278,
    40279,
    40280,
    40281,
    40282,
    40283,
    40284,
    40285,
    40286,
    68421
  ]

  constructor(private store: Store<fromRoot.State>, public dialog: MdDialog) {
    this.applyMonth = this.store.select(fromReports.getAplyMonth)
    this.applyWeek = this.store.select(fromReports.getAplyWeek)
    this.dificultyByDay = this.store.select(fromReports.getDificultyWeek)
    this.progressByDay = this.store.select(fromReports.getProgressWeek)

    this.dificultyByStudantByDay = this.store.select(fromReports.getDificultyByStudantWeek)
    this.progressByStudantByDay = this.store.select(fromReports.getProgressByStudantWeek)

    this.IsBusy = this.store.select(_ => _.report.loading);

    this.store.dispatch(new Action.LoadAplyMonthAction());
    this.store.dispatch(new Action.LoadAplyWeekAction());
    this.store.dispatch(new Action.LoadDificultyWeekAction());
    this.store.dispatch(new Action.LoadProgressWeekAction());
    // Object.assign(this, {multi, single})
  }

  GetReports() {
    this.store.dispatch(new Action.LoadDificultyByStudantWeekAction(this.studantId));
    this.store.dispatch(new Action.LoadProgressByStudantWWeekAction(this.studantId));
  }

  ngOnInit() {
  }



}

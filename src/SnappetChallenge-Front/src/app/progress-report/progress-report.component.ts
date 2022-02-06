import { Component, OnInit } from '@angular/core';

import { ReportingService } from '../services/reporting.service';
import { ChartType } from 'angular-google-charts';

@Component({
  selector: 'app-progress-report',
  templateUrl: './progress-report.component.html',
  styleUrls: ['./progress-report.component.css']
})

export class ProgressReportComponent implements OnInit {
  constructor(
    private _reportingService: ReportingService
  ) { }

  ngOnInit() {
    this.loadData();
  }

  public chartSettings = {
    type: ChartType.ColumnChart,
    columnNames: ['', 'Today', 'Last week avg'],
    options: {
      colors: ['#ccabd8', '#8474a1', '#6ec6ca', '#08979d', '#055b5c']
    },
    width: 500,
    height: 500,
    dynamicResize: true
  }

  public bySubjectChart = {
    title: 'Progress by Subject',
    data: [
      ["", 0, 0]
    ]
  }

  public byDomainChart = {
    title: 'Progress by Domain',
    data: [
      ["", 0, 0]
    ]
  }
 

  public loadData(): void {
    this._reportingService.getProgressReport()
      .subscribe(d => {
        this.bySubjectChart.data = [];
        for (let i of d.bySubjectReportData.dataSet) {
          this.bySubjectChart.data.push([
            i.data,
            i.today,
            i.lastWeek
          ])
        }

        this.byDomainChart.data = [];
        for (let i of d.byDomainReportData.dataSet) {
          this.byDomainChart.data.push([
            i.data,
            i.today,
            i.lastWeek
          ])
        }
      });
  }
}

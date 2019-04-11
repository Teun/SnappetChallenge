import { Component, OnInit } from '@angular/core';
import { ResultsServices } from '../services/results.services';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';
import { GridOptions } from 'ag-grid-community';
import * as _ from 'underscore';
import { IDetailData } from '../models/IDetailData';
import { StudentDetailsServices } from './student-details.services';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.scss']
})
export class StudentDetailsComponent implements OnInit {

  private gridOptions: GridOptions = {} as GridOptions;

  studentResult: any;
  private rowData: any;
  chartData: {
    datasets: ChartDataSets[]
    labels: Label[]
    options: ChartOptions
    legend: boolean
    chartType: ChartType
  };

  constructor(private studentDetailsServices: StudentDetailsServices, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.gridOptions.columnDefs = [
      { headerName: 'ExerciseId', field: 'exerciseId' },
      { headerName: 'SubmittedAnswerId', field: 'submittedAnswerId' },
      { headerName: 'Correct', field: 'correct' },
      { headerName: 'Subject', field: 'subject' }
    ];

    this.route.paramMap.pipe(
      tap((params: ParamMap) => {
        this.studentDetailsServices.getDetails(params.get('id')).subscribe(data => {
          this.gridOptions.rowData = data.fullData;
          this.rowData = data.fullData;
          this.renderChart(data.detailData);
        });
      })).subscribe();
  }

  renderChart(detailData: any) {

    const attempted = _.map(detailData, 'attempted');
    const correct = _.pluck(detailData, 'correct');

    this.chartData = {
      chartType: 'bar',
      labels: _.pluck(detailData, 'subject'),
      datasets: [
        { data: attempted, label: 'Exercise Attempted' },
        { data: correct, label: 'Correct Answers' }
      ],
      legend: true,
      options: {
        responsive: true,
        // We use these empty structures as placeholders for dynamic theming.
        scales: { xAxes: [{}], yAxes: [{}] },
        plugins: {
          datalabels: { anchor: 'end', align: 'end', }
        },
        events: ['click'],
        onClick: this.chartClicked
      }
    };
  }

  public chartClicked( event: MouseEvent, active: {}[]): void {
    console.log(event, active);
  }
}

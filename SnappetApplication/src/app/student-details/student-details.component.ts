import { Component, OnInit } from '@angular/core';
import { ResultsServices } from '../services/results.services';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';
import { GridOptions } from 'ag-grid-community';
import * as CanvasJS from '../../../lib/canvasjs/canvasjs.min';
import * as _ from 'underscore';
import { IDetailData } from '../models/IDetailData';
import { StudentDetailsServices } from './student-details.services';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.scss']
})
export class StudentDetailsComponent implements OnInit {

  private gridOptions: GridOptions = {} as GridOptions;

  studentResult: any;
  private rowData: any;

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
          console.log(data.fullData);
          this.rowData = data.fullData;
          this.renderChart(data.detailData);
        });
      })).subscribe();
  }

  renderChart(detailData: any) {

    const chart = new CanvasJS.Chart('chartContainer', {
      zoomEnabled: true,
      animationEnabled: true,
      exportEnabled: true,
      height: 500,
      width: 500,
      title: {
        text: 'Student Performance Detail'
      },
      data: [
        {
          type: 'column',
          name: 'Exercise Attempted',
          showInLegend: true,

          dataPoints: _.map(detailData, item => {
            return { y: item.attempted, label: item.subject };
          })
        },
        {
          type: 'column',
          name: 'Correct Answers',
          showInLegend: true,

          dataPoints: _.map(detailData, item => {
            return { y: item.correct, label: item.subject };
          })
        }]
    });

    chart.render();
  }
}

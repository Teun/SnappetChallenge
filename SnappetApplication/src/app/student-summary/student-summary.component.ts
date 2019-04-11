import { Component, OnInit } from '@angular/core';
import { ResultsServices } from '../services/results.services';
import * as CanvasJS from '../../../lib/canvasjs/canvasjs.min';
import * as _ from 'underscore';
import { Router } from '@angular/router';
import { StudentSummaryServices } from './student-summary.service';

@Component({
  selector: 'app-class-summary',
  templateUrl: './student-summary.component.html',
  styleUrls: ['./student-summary.component.scss']
})
export class StudentSummaryComponent implements OnInit {

  classData: any;
  constructor(private summaryServices: StudentSummaryServices, private router: Router) { }

  ngOnInit() {
    this.summaryServices.getSummary()
      .subscribe(data => {
        this.classData = data;

        const chart = new CanvasJS.Chart('chartContainer', {
          zoomEnabled: true,
          animationEnabled: true,
          exportEnabled: true,
          height : 600,
          title: {
            text: 'Student Performance Summary'
          },
          data: [
            {
              type: 'stackedColumn',
              name: 'Exercise Attempted',
              showInLegend: true,
              click: (event) => {
                this.gotoDetails(event.dataPoint.id);
              },
              dataPoints: _.map(this.classData, item => {
                return { y: item.attempted, label: item.name, id: item.id };
              })
            },
            {
              type: 'stackedColumn',
              name: 'Correct Answers',
              showInLegend: true,
              click: (event) => {
                this.gotoDetails(event.dataPoint.label);
              },
              dataPoints: _.map(this.classData, item => {
                return { y: item.correct, label: item.name, id: item.id };
              })
            }]
        });

        chart.render();
      });

  }

  gotoDetails(id: string) {
    this.router.navigate([`/results/${id}`]);
  }
}

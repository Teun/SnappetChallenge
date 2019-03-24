import { Component, OnInit } from '@angular/core';
import { ClassDataServices } from '../services/class-data.services';
import * as CanvasJS from '../../../lib/canvasjs/canvasjs.min';
import * as _ from 'underscore';
import { Router } from '@angular/router';

@Component({
  selector: 'app-class-summary',
  templateUrl: './student-summary.component.html',
  styleUrls: ['./student-summary.component.scss']
})
export class StudentSummaryComponent implements OnInit {

  classData: any;
  constructor(private classDataServices: ClassDataServices, private router: Router) { }

  ngOnInit() {
    this.classDataServices.getAllData()
      .subscribe(data => {
        this.classData = data;

        // console.log(this.classData);

        const chart = new CanvasJS.Chart('chartContainer', {
          zoomEnabled: true,
          animationEnabled: true,
          exportEnabled: true,
          title: {
            text: 'Student Performance Summary'
          },
          data: [
            {
              type: 'bar',
              name: 'Exercise Attempted',
              showInLegend: true,
              click: (event) => {
                this.gotoDetails(event.dataPoint.label);
              },
              dataPoints: _.map(this.classData, item => {
                return { y: item.attempted, label: item.name };
              })
            },
            {
              type: 'bar',
              name: 'Correct Answers',
              showInLegend: true,
              click: (event) => {
                this.gotoDetails(event.dataPoint.label);
              },
              dataPoints: _.map(this.classData, item => {
                return { y: item.correct, label: item.name };
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

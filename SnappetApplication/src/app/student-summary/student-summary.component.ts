import { Component, OnInit } from '@angular/core';
import { ResultsServices } from '../services/results.services';
import * as _ from 'underscore';
import { Router } from '@angular/router';
import { StudentSummaryServices } from './student-summary.service';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';

@Component({
  selector: 'app-class-summary',
  templateUrl: './student-summary.component.html',
  styleUrls: ['./student-summary.component.scss']
})
export class StudentSummaryComponent implements OnInit {

  classData: any;
  chartData: {
    datasets: ChartDataSets[]
    labels: Label[]
    options: ChartOptions
    legend: boolean
    chartType: ChartType
    ids?: any
  };

  chartPlugins = [pluginDataLabels];

  constructor(private summaryServices: StudentSummaryServices, private router: Router) { }

  ngOnInit() {
    this.summaryServices.getSummary()
      .subscribe(data => {
        this.classData = data;

        const attempted = _.pluck(this.classData, 'attempted');
        const correct = _.pluck(this.classData, 'correct');

        // const labels = _.map(this.classData, (item) => {
        //   return { id: item.id, name: item.name };
        // });

        const labels = _.pluck(this.classData, 'name');

        const ids = _.pluck(this.classData, 'id');

        console.log(labels);

        this.chartData = {
          chartType: 'bar',
          labels: labels,
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
              datalabels: {
                anchor: 'end', align: 'end'
                // formatter: (value, ctx) => {
                //   const label = ctx.chart.data.labels[ctx.dataIndex] as any;
                //   console.log(label);
                //   return label.name;
                // }
              }
            },
            events: ['click'],
            onClick: this.chartClicked(ids)
          }
        };
      });

  }

  public chartClicked = (ids: string[]) => {
    return (event: MouseEvent, active: any[]): void => {
      const index = active[0]._index;
      const id = ids[index];
      this.gotoDetails(id);
    };

    // this.gotoDetails(event.dataPoint.id);
  }

  gotoDetails(id: string) {
    this.router.navigate([`/results/${id}`]);
  }
}

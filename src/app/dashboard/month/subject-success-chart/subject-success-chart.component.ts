import {Component, Input} from '@angular/core';
import {ChartData, ChartOptions, ChartType} from "chart.js";

@Component({
  selector: 'app-subject-success-chart',
  templateUrl: './subject-success-chart.component.html',
  styleUrls: ['./subject-success-chart.component.scss']
})
export class SubjectSuccessChartComponent {
  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];

  @Input() barChartData: ChartData<'bar'> = {
    labels: [],
    datasets: [
      {data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A'},
      {data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B'}
    ]
  };

  constructor() {}
}

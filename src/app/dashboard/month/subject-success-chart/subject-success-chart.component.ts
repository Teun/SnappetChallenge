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
  public barChartLabels = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];

  @Input() barChartData: ChartData<'bar'> = {
    labels: [],
    datasets: []
  };

  constructor() {}
}

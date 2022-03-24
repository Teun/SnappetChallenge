import {Component, Input} from '@angular/core';
import {ChartData, ChartOptions, ChartType} from "chart.js";

@Component({
  selector: 'app-subject-split-chart',
  templateUrl: './subject-split-chart.component.html',
  styleUrls: ['./subject-split-chart.component.scss']
})
export class SubjectSplitChartComponent {
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels = [];
  @Input() pieChartData: ChartData<'pie'> = {
  labels: [],
  datasets: []
};

  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];

  constructor() { }
}

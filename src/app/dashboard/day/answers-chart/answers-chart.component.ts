import {Component, Input} from '@angular/core';
import {ChartOptions, ChartType, ChartData} from "chart.js";

@Component({
  selector: 'app-answers-chart',
  templateUrl: './answers-chart.component.html',
  styleUrls: ['./answers-chart.component.scss']
})
export class AnswersChartComponent {
  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels: string[] = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];

  @Input() barChartData: ChartData<'bar'> = {
    labels: [],
    datasets: []
  };

  constructor() {}
}

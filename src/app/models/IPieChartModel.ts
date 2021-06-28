import {ChartOptions, ChartType} from "chart.js";

export interface IPieChartModel {
  pieChartType: ChartType;
  pieChartData: number[];
  pieChartLabels: string[];
  pieChartLegend: boolean;
  pieChartColors: any[];
  pieChartOptions: ChartOptions;
  pieChartPlugins: any;
}

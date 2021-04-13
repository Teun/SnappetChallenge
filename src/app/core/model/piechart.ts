import { ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';

export interface PieChartModel {
   pieChartLabels: Label[];
   pieChartData: any[];
   pieChartType: ChartType;
   pieChartLegend: boolean;
   pieChartColors: Color[];
   pieChartOptions: any;
   pieChartPlugins: any;
}

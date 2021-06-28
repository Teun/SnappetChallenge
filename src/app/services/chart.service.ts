import {Injectable} from '@angular/core';
import {IStudentData} from "../models/IStudentData";
import {ChartOptions} from "chart.js";
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import {IPieChartModel} from "../models/IPieChartModel";

@Injectable({
  providedIn: 'root'
})
export class ChartService {
  colors = [{
    backgroundColor: ['#f50808', '#61ef12', '#005def', '#f900c2', '#ffef00',
      '#edc951', '#eb6841', '#cc2a36', '#4f372d', '#00a0b0',
      '#740c9a', '#4e4ec4', '#21b0ff', '#aa52b4', '#ff218c',
      '#dfff98', '#ffaef3', '#d0a9e1', '#1e79bd', '#00391c',
      '#e0218a', '#61892f', '#e5e187', '#ab9472', '#cc3b3b']
  }];

  constructor() {
  }

  getLearningObjectivePieChartModel(data: IStudentData[]): IPieChartModel {
    let chartConfigs = this.getChartLabelsAndData(data, 'LearningObjective');
    return this.createPieChartModel(chartConfigs);
  }

  getSubjectPieChartModel(data: IStudentData[]): IPieChartModel {
    let chartConfigs = this.getChartLabelsAndData(data, 'Subject');
    return this.createPieChartModel(chartConfigs);
  }

  getDomainPieChartModel(data: IStudentData[]): IPieChartModel {
    let chartConfigs = this.getChartLabelsAndData(data, 'Domain');
    return this.createPieChartModel(chartConfigs);
  }

  private getChartLabelsAndData(data: IStudentData[], attributeName: string) {
    let _data: number[] = [], _labels: string[] = [];
    let o: any = {};
    data.forEach((fd: IStudentData) => {
      const formatAttributeName = attributeName as keyof typeof fd;
      o[fd[formatAttributeName]] = Object.keys(o).includes(<string>fd[formatAttributeName]) ? o[fd[formatAttributeName]] + 1 : 1;
    })
    for (const [key, value] of Object.entries(o)) {
      _labels.push(key);
      _data.push(typeof value === "number" ? value : 0);
    }
    return {data: _data, labels: _labels};
  }

  private createPieChartModel(chartConfigs: { data: number[]; labels: string[]; }): IPieChartModel {
    return {
      pieChartType: 'pie',
      pieChartData: chartConfigs.data,
      pieChartLabels: chartConfigs.labels,
      pieChartLegend: true,
      pieChartColors: this.colors,
      pieChartOptions: ChartService.getPieChartOptions(),
      pieChartPlugins: [pluginDataLabels]
    }
  }

  private static getPieChartOptions() {
    const pieChartOptions: ChartOptions = {
      responsive: true,
      legend: {
        position: 'right'
      },
      plugins: {
        datalabels: {
          formatter: (value: any, ctx: any) => {
            let sum = 0;
            let dataArr = ctx.chart.data.datasets[0].data;
            dataArr.map((data: any) => {
              sum += data;
            });
            let percentage = (value * 100 / sum).toFixed(2);
            return +percentage > 3 ? `${percentage}%` : '';
          },
          color: '#ffffff'
        },
      }
    }
    return pieChartOptions;
  }

}

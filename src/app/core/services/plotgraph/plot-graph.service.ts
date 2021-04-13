import { Injectable } from '@angular/core';
import * as Chart from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Observable, ReplaySubject } from 'rxjs';
import { BarChartModel } from '../../model/barchart';
import { GraphData } from '../../model/graphdata';
import { Overview } from '../../model/overview';
import { PieChartModel } from '../../model/piechart';

/*  PlotGraphService 
  - which has all the business logic to populate the different charts in dashboard */
@Injectable({
  providedIn: 'root'
})
export class PlotGraphService {

  /* Using Replay subject for the late subscribers who needs the display the charts
    - avoids complex for loop operations for new subscribers
  */
  graphDataSubject = new ReplaySubject<GraphData>();
  graphData$ = this.graphDataSubject.asObservable();

  topSubjects: any = {};
  topDomain: any = {};
  topObjective: any = {};
  topPerformers: any = {};
  diffiCultExcerciseRaw: any = {};
  stdCompletingDiffExcercise: any = {};
  colors = [{ backgroundColor:
      ['rgba(255,0,0,0.3)', 'rgba(0,255,0,0.3)', 'rgba(0,0,255,0.3)',
      'orange', 'yellow', 'pink', 'red', 'green', 'white']
  }];

  constructor() { }

  /* public API of the service which is invoked from the component
    - calls necessary functions to create the different chart data */
  plotChartData(rawData: Overview[], dateFilter: string[]): Observable<GraphData>{
    this.initialiseVariables();
    rawData.forEach((data: Overview) => {
      if (data.SubmitDateTime.split('T')[0] === dateFilter[0]) {
        this.createDifferentGraph(data);
      }
    });
    this.graphDataSubject.next({

      objectiveChart: this.createPieChartModel(this.topObjective, false),
      subjectChart: this.createPieChartModel(this.topSubjects, true),
      domainChart: this.createPieChartModel(this.topDomain, true),
      topPerformerChart: this.createBarChartModel(this.topPerformers, 'rgba(255,0,0,0.3)'),
      studentsFinishingDiffExcChart: this.createBarChartModel(this.stdCompletingDiffExcercise, 'rgba(0,255,0,0.3)'),
      diffcultExcerciseChart: this.createExcPieChartModel(this.getsortMostDifficultExcercise())

    });
    return this.graphData$;
  }

  createDifferentGraph(data: Overview): void {
    this.topPerformersOfDay(data);
    this.getDifficultExcercise(data);
    this.getStdDoingDifficultSubject(data);
    this.topSubjects[data.Subject] = this.topSubjects[data.Subject] ? this.topSubjects[data.Subject] + 1 : 1;
    this.topDomain[data.Domain] = this.topDomain[data.Domain] ? this.topDomain[data.Domain] + 1 : 1;
    this.topObjective[data.LearningObjective] = this.topObjective[data.LearningObjective] ? 
    this.topObjective[data.LearningObjective] + 1 : 1;
  }

  initialiseVariables(): void {
    this. topSubjects = {};
    this.topDomain = {};
    this.topObjective = {};
    this.topPerformers = {};
    this.diffiCultExcerciseRaw = {};
    this.stdCompletingDiffExcercise = {};
  }


  createBarChartModel(data, color): BarChartModel {
    return {
      barChartType: 'bar',
      barChartLabels:  Object.keys(data),
      barChartLegend: true,
      barChartData: Object.values(data),
      barChartColors: [{backgroundColor: color}]
    };
  }

  createPieChartModel(object: any, showLabel: boolean): PieChartModel {
    return {
      pieChartType: 'pie',
      pieChartData: Object.values(object).slice(0, 5),
      pieChartLabels: Object.keys(object).slice(0, 5),
      pieChartLegend: true,
      pieChartColors: this.colors,
      pieChartPlugins: pluginDataLabels,
      pieChartOptions: this.getPieChartOptions(showLabel)
    };
  }

  createExcPieChartModel(data): PieChartModel {
    return {
      pieChartType: 'pie',
      pieChartData: data.values.slice(0, 7),
      pieChartLabels: data.exc.slice(0, 7),
      pieChartLegend: true,
      pieChartColors: this.colors,
      pieChartPlugins: pluginDataLabels,
      pieChartOptions: this.getPieChartOptions(true)
    };
  }

  getPieChartOptions(showLabel: boolean): any {
    const pieChartOptions: Chart.ChartOptions = {
      responsive: true,
      legend: {
        position: 'top',
      },
      plugins: {
        datalabels: {
          formatter: (value, ctx: any) => {
            const label = ctx.chart.data.labels[ctx.dataIndex];
            return showLabel ? label : '';
          },
        },
      }
    };
    return pieChartOptions;
  }

  topPerformersOfDay(data: Overview): void {
    if (data.Correct) {
      this.topPerformers[data.UserId] = this.topPerformers[data.UserId] ?
        this.topPerformers[data.UserId] + data.Correct : data.Correct;
    }
  }

  getDifficultExcercise(data: Overview): void {
    if (data.Progress <= 0) {
      this.diffiCultExcerciseRaw[data.ExerciseId] = this.diffiCultExcerciseRaw[data.ExerciseId] ?
        this.diffiCultExcerciseRaw[data.ExerciseId] + 1 : 1;
    }
  }

  getsortMostDifficultExcercise(): any {
    const sortedTopDifficultExc: any = {exc: [], values: []};
    Object.entries(this.diffiCultExcerciseRaw).sort((a: any, b: any) => b[1] - a[1]).forEach(
      item => {
        sortedTopDifficultExc.exc.push(item[0]);
        sortedTopDifficultExc.values .push(item[1]);
      }
    );
    return sortedTopDifficultExc;
  }

  getStdDoingDifficultSubject(data: Overview): void {
    if (parseInt(data.Difficulty) > 350 && data.Correct >= 1) {
      this.stdCompletingDiffExcercise[data.UserId] = this.stdCompletingDiffExcercise[data.UserId] ?
      this.stdCompletingDiffExcercise[data.UserId] + 1 : 1;
    }
  }
}


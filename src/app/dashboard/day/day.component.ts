import { Component, OnInit } from '@angular/core';
import {DashboardService} from "../dashboard.service";
import {ChartData} from "chart.js";
import {CardData} from "../dashboard";
import {isSameDay} from "../date-utils";

@Component({
  selector: 'app-day',
  templateUrl: './day.component.html',
  styleUrls: ['./day.component.scss']
})
export class DayComponent implements OnInit {
  public isSameDay = isSameDay;

  currentDate: Date = this.dashboardService.currentDate;
  selectedDate: Date = new Date();
  chartData: ChartData<'bar'> = {
    labels: [],
    datasets: []
  };

  public report: CardData = {
    submittedEntries: 0,
    correctEntries: 0,
    successRate: 0,
    studentNumber: 0,
  };

  constructor(private dashboardService: DashboardService) { }

  ngOnInit(): void {
    this.selectedDate = this.currentDate;

    this.report = this.dashboardService.getReport(this.selectedDate, true);

    this.setChartData();
  }

  switchDay(diff: number) {
    const day = this.selectedDate.getDate() + diff;

    this.selectedDate = new Date(this.selectedDate.getFullYear(), this.selectedDate.getMonth(), day);

    this.report = this.dashboardService.getReport(this.selectedDate, this.isSameDay(this.selectedDate, this.currentDate));

    this.setChartData();
  }

  setChartData() {
    const students = this.dashboardService.getStudentsWithResults(this.selectedDate);

    this.chartData = {
      labels: students.map(({id}) => id),
      datasets: [
        {
          data: students.map(({answers}) => answers.total),
          label: 'Completed Tasks'
        },
        {
          data: students.map(({answers}) => answers.correct),
          label: 'Correct answers'
        },
      ]
    };
  }
}

import { Component } from '@angular/core';
import {DashboardService} from "../dashboard.service";
import {MatSelectChange} from "@angular/material/select";
import {Student} from "../dashboard";
import {ChartData} from "chart.js";

@Component({
  selector: 'app-month',
  templateUrl: './month.component.html',
  styleUrls: ['./month.component.scss']
})
export class MonthComponent {
  student?: Student;
  splitChartData: ChartData<'pie'> = {
    labels: [],
    datasets: []
  };
  successChartData: ChartData<'bar'> = {
    labels: [],
    datasets: []
  };
  public monthData = this.dashboardService.getMonthData();
  public students = this.dashboardService.getAllStudents();
  public currentDate = this.dashboardService.currentDate;

  constructor(private dashboardService: DashboardService) {}

  onStudentSelect(evt: MatSelectChange) {
    this.student = this.dashboardService.getStudent(evt.value);

    this.splitChartData = {
      labels: Object.keys(this.student.subjectSplit),
      datasets: [{
        data: Object.values(this.student.subjectSplit),
      }]
    };

    this.successChartData = {
      labels: Object.keys(this.student.subjectSuccessRate),
      datasets: [{
        data: Object.values(this.student.subjectSuccessRate),
        label: 'Success rate'
      }]
    };
  }
}

import { Component, OnInit } from '@angular/core';
import { ChartType } from 'angular-google-charts';
import { IStudentData } from '../models/IStudentData';
import { ReportsService } from '../services/reports.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  studentData: IStudentData[] = [];
  filteredStudentData: IStudentData[] = [];
  today: string = '2015-03-24';

  chart1Data: any[] = [];
  chart1Config = {
    options: {
      height: 500,
      width: 500,
      is3D: true,
    },
    type: ChartType.PieChart,
    title: "Students and their Learning Objectives"
  }

  chart2Data: any[] = [];
  chart2Config = {
    options: {
      height: 500,
      width: 500,
      is3D: true,
    },
    type: ChartType.PieChart,
    title: "Students and their Subjects"
  }

  chart3Data: { UserId: string, Progress: number }[] = [];
  chart4Data: any[] = [];
  chart4Config = {
    options: {
      height: 500,
      width: 500,
      is3D: true,
    },
    type: ChartType.BarChart,
    title: "Number of Students per Domain"
  }

  subjects: string[] = [];

  //chart4Data: { Domain: string, Count: number }[] = [];

  selectedTab: string | 'dashboard' | 'studentData' = '';

  constructor(private reportsService: ReportsService) {

  }

  ngOnInit(): void {
    this.reportsService.getAllStudentData().subscribe(data => {
      this.studentData = data;
      this.loadReports();
    });
  }

  onDateChange() {
    this.loadReports();
  }

  loadReports() {
    this.reset();
    this.getStudentData(this.today);
    this.setSubjects();
    this.setCharts();
    this.selectedTab = 'dashboard';
  }

  reset() {
    this.chart1Data = [];
    this.chart2Data = [];
    this.chart3Data = [];
    this.chart4Data = [];
    this.subjects = [];
  }

  getStudentData(dateTime: string) {
    this.filteredStudentData = this.studentData.filter(s => this.extractDate(s.SubmitDateTime) == dateTime);
  }

  private extractDate(dateTime: string): string {
    return dateTime.split('T')[0]
  }

  selectTab(tab: string) {
    this.selectedTab = tab;
  }

  setCharts() {
    this.setChart1Data();
    this.setChart2Data();
    this.setChart4Data();
  }

  setChart1Data() {
    let dict: any = {};
    this.filteredStudentData.forEach(fd => {
      if (Object.keys(dict).includes(fd.LearningObjective))
        dict[fd.LearningObjective] = dict[fd.LearningObjective] + 1;
      else
        dict[fd.LearningObjective] = 0;
    });
    Object.keys(dict).forEach(key => {
      this.chart1Data.push([key, dict[key]]);
    });
  }

  setChart2Data() {
    let dict: any = {};
    this.filteredStudentData.forEach(fd => {
      if (Object.keys(dict).includes(fd.Subject))
        dict[fd.Subject] = dict[fd.Subject] + 1;
      else
        dict[fd.Subject] = 0;
    });

    Object.keys(dict).forEach(key => {
      this.chart2Data.push([key, dict[key]]);
    });
  }

  setSubjects() {
    this.filteredStudentData.forEach(fd => {
      if (!this.subjects.includes(fd.Subject))
        this.subjects.push(fd.Subject);
    });
  }

  onSubjectChange(event: any) {
    const subject = event.target.value;
    this.setChart3Data(subject);
  }

  setChart3Data(subject: string) {
    let subjectData = this.filteredStudentData.filter(fd => fd.Subject == subject);
    let dict: any = {};
    subjectData.forEach(sub => {
      if (Object.keys(dict).includes(sub.UserId.toString())) {
        if (dict[sub.UserId] < sub.Progress) {
          dict[sub.UserId] = sub.Progress;
        }
      }
      else
        dict[sub.UserId] = sub.Progress;
    })

    this.chart3Data = [];
    Object.keys(dict).forEach(key => {
      this.chart3Data.push({ UserId: key, Progress: dict[key] });
    })

    this.chart3Data = this.chart3Data.sort((a, b) => {
      return b.Progress - a.Progress
    }).slice(0, 5);
  }

  setChart4Data() {
    let uniqueRecords: IStudentData[] = [];
    this.filteredStudentData.forEach(data => {
      if (!uniqueRecords.find(d => d.Domain == data.Domain && d.UserId == data.UserId)) {
        uniqueRecords.push(data);
      }
    });

    let dict: any = {};
    uniqueRecords.forEach(r => {
      if (Object.keys(dict).includes(r.Domain)) {
        dict[r.Domain] += 1;
      }
      else
        dict[r.Domain] = 1
    });

    Object.keys(dict).forEach(key => {
      this.chart4Data.push([key, dict[key]]);
    })
  }
}

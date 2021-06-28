import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ReportService} from "../services/report.service";
import {IStudentData} from "../models/IStudentData";
import {ChartService} from "../services/chart.service";
import {IPieChartModel} from "../models/IPieChartModel";

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {
  form: FormGroup;
  studentsData: IStudentData[] = [];
  filteredData: IStudentData[] = [];
  learningObjectivePieChartModel: IPieChartModel | undefined;
  subjectPieChartModel: IPieChartModel | undefined;
  domainPieChartModel: IPieChartModel | undefined;
  showReport: boolean = false;
  subjects: string[] = [];
  selectedSubject: string | undefined;
  topPerformingStudents: any[] = [];
  tableColumns: any[] = [];

  constructor(private fb: FormBuilder,
              private reportService: ReportService,
              private chartService: ChartService) {
    this.form = this.fb.group({
      date: [new Date('2015-03-24'), Validators.required],
    })
  }

  ngOnInit(): void {
    this.getStudentData();
  }

  getStudentData() {
    this.reportService.getStudentsData().subscribe((res: Array<IStudentData>) => {
      this.studentsData = res;
      this.generateReport();
    }, error => {
    })
  }

  generateReport() {
    let selectedDate = this.form.value.date;
    selectedDate = this.formatDate(selectedDate);

    this.filteredData = this.studentsData.filter(d => this.extractDate(d.SubmitDateTime) === selectedDate);
    this.showReport = this.filteredData && this.filteredData.length > 0;
    this.learningObjectivePieChartModel = this.chartService.getLearningObjectivePieChartModel(this.filteredData);
    this.subjectPieChartModel = this.chartService.getSubjectPieChartModel(this.filteredData);
    this.domainPieChartModel = this.chartService.getDomainPieChartModel(this.filteredData);

    this.setSubjects();
    this.getTopPerformingStudents();
  }

  formatDate(dateObject: any): string {
    let month = dateObject.getMonth() + 1;
    month = month < 10 ? `0${month}` : month;
    let date = dateObject.getDate();
    let year = dateObject.getFullYear();

    return `${year}-${month}-${date}`;
  }

  extractDate(date: string) {
    return date.split('T')[0];
  }

  getTopPerformingStudents() {
    let subjectData = this.filteredData.filter(fd => fd.Subject === this.selectedSubject);
    let o: any = {};
    subjectData.forEach(sd => {
      if (Object.keys(o).includes(sd.UserId.toString())) {
        if (o[sd.UserId] < sd.Progress) {
          o[sd.UserId] = sd.Progress;
        }
      } else
        o[sd.UserId] = sd.Progress;
    })

    let _data = [];
    for (const [key, value] of Object.entries(o)) {
      _data.push({userId: key, progress: o[key]})
    }

    this.topPerformingStudents = _data.sort((a, b) => {
      return b.progress - a.progress
    }).slice(0, 5);
    this.tableColumns = ['userId', 'progress'];
  }

  private setSubjects() {
    this.filteredData.forEach(fd => {
      if (!this.subjects.includes(fd.Subject))
        this.subjects.push(fd.Subject);
    });
    this.selectedSubject = this.subjects[0];
  }

}

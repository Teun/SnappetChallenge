import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {BaseHttpService} from '../../services/base-http.service';
import {ITdDataTableColumn} from '@covalent/core/data-table';
import {formatDate} from '@angular/common';

@Component({
  selector: 'app-progress',
  templateUrl: './progress.component.html',
  styleUrls: ['./progress.component.scss']
})
export class ProgressComponent implements OnInit {

  _baseUrl = 'http://localhost:3000';

  studentController = new FormControl();
  students = [];
  subjectConfigWidthColumns: ITdDataTableColumn[] = [
    {name: 'time', label: 'Submit Day'},
    {name: 'subject', label: 'Subject'},
    {name: 'progress', label: 'Progress'},
    {name: 'correct', label: 'Correct Answers'},
    {name: 'difficulty', label: 'Difficulty'},
  ];
  learningConfigWidthColumns: ITdDataTableColumn[] = [
    {name: 'time', label: 'Submit Day'},
    {name: 'objective', label: 'Learning Objective'},
    {name: 'progress', label: 'Progress'},
    {name: 'correct', label: 'Correct Answers'},
    {name: 'difficulty', label: 'Difficulty'},
  ];
  subject_reports: any;
  learning_reports: any;
  learning_report: any;
  view = true;
  dateForm: FormGroup;

  constructor(private httpService: BaseHttpService) {
    this.dateForm = new FormGroup({
      start: new FormControl(new Date(2015, 2, 24))
    })
  }

  ngOnInit(): void {
    this.httpService.get(`${this._baseUrl}/filter`).subscribe(value => {
      this.students = value.students;
    });
  }

  studentFilterChanged(event: any) {
    this.httpService.get(`${this._baseUrl}/progress?student_id=${event}`).subscribe(report => {
      this.subject_reports = [];
      for (const rep of report.subject) {
        for (const sub of rep) {
          this.subject_reports.push(sub);
        }
      }
      this.learning_reports = report.learning;

      this.learning_report = [];
      const reports = this.learning_reports.filter(value => value.some(val => val.time === '2015-03-24'));
      if (!reports) return;
      for (const rep of reports[0]) {
        this.learning_report.push(rep);
      }
    });
  }

  viewChanged(event) {
    this.view = !this.view;
  }

  dateChange(event) {
    const time = formatDate(event.value, 'YYYY-MM-dd', 'en-US');
    this.learning_report = [];
    const report = this.learning_reports.filter(value => value.some(val => val.time === time));
    if (!report) return;
    for (const rep of report[0]) {
      this.learning_report.push(rep);
    }
  }
}

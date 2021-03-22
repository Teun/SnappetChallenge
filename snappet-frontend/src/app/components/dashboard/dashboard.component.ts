import {Component, OnInit} from '@angular/core';
import {BaseHttpService} from '../../services/base-http.service';
import {FormControl, FormGroup} from '@angular/forms';
import {DateRange, ExtractDateTypeFromSelection, MatDatepickerInputEvent} from '@angular/material/datepicker';
import {formatDate} from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  _baseUrl = 'http://localhost:3000';

  students: string[];
  learnings: string[];
  subjects: string[];

  studentController = new FormControl();
  learningController = new FormControl();
  subjectsController = new FormControl();

  config: any;

  chosenStudents = [];
  chosenLearnings = [];
  chosenSubjects = [];
  beginDate = '2015-03-24';
  endDate = '2015-03-25';

  subjectData: any;
  learningData: any;
  dateForm: any;

  constructor(private httpService: BaseHttpService) {
  }

  ngOnInit(): void {
    this.dateForm = new FormGroup({
      start: new FormControl(new Date(2015, 2, 24)),
      end: new FormControl(new Date(2015, 2, 25))
    });
    this.retrieveFilterData();
    this.retrieveData();
  }

  retrieveFilterData() {
    this.httpService.get(`${this._baseUrl}/filter`).subscribe(value => {
      this.students = value.students;
      this.learnings = value.learnings;
      this.subjects = value.subjects;
    });
  }

  retrieveData() {
    this.httpService.post(`${this._baseUrl}/reports`, {beginDate: this.beginDate, endDate: this.endDate}).subscribe(reports => {
      this.subjectData = reports.subject;
      this.learningData = reports.learning;
    });
  }

  studentFilterChanged(event: any) {
    this.chosenStudents = event;
    this.filterChanged();
  }

  learningFilterChanged(event: any) {
    this.chosenLearnings = event;
    this.filterChanged();
  }

  subjectFilterChanged(event: any) {
    this.chosenSubjects = event;
    this.filterChanged();
  }

  beginDateChange() {
    this.beginDate = formatDate(this.dateForm.value.start, 'YYYY-MM-dd', 'en-US');
  }

  endDateChange() {
    if (this.dateForm.value.end) {
      this.endDate = formatDate(this.dateForm.value.end, 'YYYY-MM-dd', 'en-US');
      this.filterChanged();
    }
  }

  private filterChanged() {
    const filter = {
      student: this.chosenStudents,
      learning: this.chosenLearnings,
      subject: this.chosenSubjects,
      beginDate: this.beginDate,
      endDate: this.endDate
    };

    this.httpService.post(`${this._baseUrl}/reports`, filter).subscribe(reports => {
      this.subjectData = reports.subject;
      this.learningData = reports.learning;
    });
  }
}

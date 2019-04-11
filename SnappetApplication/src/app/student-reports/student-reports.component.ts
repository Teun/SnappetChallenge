import { Component, OnInit } from '@angular/core';
import { StudentReportServices } from './student-reports.services';

@Component({
  selector: 'app-student-reports',
  templateUrl: './student-reports.component.html',
  styleUrls: ['./student-reports.component.scss']
})
export class StudentReportsComponent implements OnInit {

  top10: any[];
  bottom10: any[];
  constructor(private studentReportsService: StudentReportServices) { }

  ngOnInit() {
    this.studentReportsService.getTop10().subscribe(data => this.top10 = data);
    this.studentReportsService.getBottom10().subscribe(data => this.bottom10 = data);
  }

}

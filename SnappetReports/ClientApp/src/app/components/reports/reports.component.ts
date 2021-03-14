import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  public reportRecords: ReportRecord[]
  public reportSubjectAnswerCount: SubjectAnswerCount[]

  constructor(private service: ReportsService) { }


  ngOnInit() {
    this.service.GetReportJSON().subscribe(reportRecordData => {
      this.reportRecords = reportRecordData;
    })

    this.service.GetSubjectAnswerCount().subscribe(subjectAnswerData => {
      this.reportSubjectAnswerCount = subjectAnswerData;
    })
  }

}

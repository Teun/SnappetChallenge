import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  public reportRecords: ReportRecord[]
  public reportSubjectAnswerCount: SubjectAnswerCount[]
  
  dtOptions: DataTables.Settings = {};
  public reportDailySubjects: SubjectDailyReport[]
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private service: ReportsService) { }


  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5
    };

    this.service.GetReportJSON().subscribe(reportRecordData => {
      this.reportRecords = reportRecordData;
    })

    this.service.GetSubjectAnswerCount().subscribe(subjectAnswerData => {
      this.reportSubjectAnswerCount = subjectAnswerData;
    })


    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5
    };

    this.service.GetSubjectDailyReports().subscribe(subjectDailyData => {
      this.reportDailySubjects = subjectDailyData;
      this.dtTrigger.next();
    });


  }

}

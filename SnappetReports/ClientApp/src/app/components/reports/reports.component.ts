import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  public reportRecords: ReportRecord[]

  constructor(private service: ReportsService) { }


  ngOnInit() {
    this.service.GetReportRecords().subscribe(data => {
      this.reportRecords = data;
    })
  }

}

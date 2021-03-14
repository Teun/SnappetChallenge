import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  reportRecords: ReportRecord[] = [];

  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private service: ReportsService) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2
    };


    this.service.GetReportRecords().subscribe(data => {
      this.reportRecords = data;

        // Calling the DT trigger to manually render the table
        this.dtTrigger.next();
      });
  }

}

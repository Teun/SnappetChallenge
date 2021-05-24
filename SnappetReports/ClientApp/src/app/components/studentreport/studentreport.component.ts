import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-studentreport',
  templateUrl: './studentreport.component.html',
  styleUrls: ['./studentreport.component.css']
})
export class StudentreportComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  reportRecords: UserRport[] = [];
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private service: ReportsService) { }

  ngOnInit() {

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5
    };

    this.service.GetUserReports().subscribe(data => {
      this.reportRecords = data;
      this.dtTrigger.next();
    });

  }

}

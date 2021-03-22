import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ColumnMode } from '@swimlane/ngx-datatable';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { IDateRange } from '../models/date-range-model';
import { ISubjectStudentOverview } from '../models/subject-student-overview.model';
import { EducatorSubjectOverviewService } from './educator-subject-overview.service';

@Component({
  selector: 'app-educator-subject-overview',
  templateUrl: './educator-subject-overview.component.html',
  styleUrls: ['./educator-subject-overview.component.scss']
})
export class EducatorSubjectOverviewComponent implements OnInit {
  @ViewChild('mySubjectOverviewTable') table: any;
  gridColumnMode: ColumnMode = ColumnMode.force;
  
  subject: string;
  fromDateFormattedString: string;
  toDateFormattedString: string;
  educatorSubjectStudentOverview$: Observable<ISubjectStudentOverview[]>;

  constructor(
    private route: ActivatedRoute, 
    private educatorSubjectOverviewService: EducatorSubjectOverviewService) { 
  }

  ngOnInit(): void {
    // TODO: Should validate here, but limited due to time constraint.
    this.subject = this.route.snapshot.paramMap.get('subject');
    const fromDateIso = this.route.snapshot.queryParamMap.get('fromDate');
    const toDateIso = this.route.snapshot.queryParamMap.get('toDate');

    const dateRange: IDateRange = {
      fromDate: new Date(fromDateIso), 
      toDate: new Date(toDateIso)
    }

    this.fromDateFormattedString = moment(dateRange.fromDate).format('MMMM Do YYYY, h:mm:ss a');
    this.toDateFormattedString = moment(dateRange.toDate).format('MMMM Do YYYY, h:mm:ss a');

    this.educatorSubjectStudentOverview$ = this.educatorSubjectOverviewService.get(this.subject, dateRange);
  }

  toggleExpandRow(row) : boolean {
    this.table.rowDetail.toggleExpandRow(row);
    return false;
  }
}

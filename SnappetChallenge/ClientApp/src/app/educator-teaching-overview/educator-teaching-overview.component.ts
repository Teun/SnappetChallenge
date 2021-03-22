import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable'
import { EducatorTeachingOverviewService } from './educator-teaching-overview.service';
import { Observable } from 'rxjs';
import { ISubjectOverview } from '../models/subject-overview.model';
import * as moment from 'moment';
import { ThemePalette } from '@angular/material/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-educator-teaching-overview',
  templateUrl: './educator-teaching-overview.component.html',
  styleUrls: ['./educator-teaching-overview.component.scss']
})
export class EducatorTeachingOverviewComponent implements OnInit {
  private lastAppliedDateRange = this.educatorTeachingOverviewService.defaultDateRange;

  @ViewChild('myTable') table: any;
  @ViewChild('fromPicker') fromPicker: any;
  @ViewChild('toPicker') toPicker: any;

  minDate: moment.Moment;
  maxDate: moment.Moment;
  dateTimePickerColour: ThemePalette = 'primary';
  fromDateControl = new FormControl(this.educatorTeachingOverviewService.defaultDateRange.fromDate);
  toDateControl = new FormControl(this.educatorTeachingOverviewService.defaultDateRange.toDate);

  gridColumnMode: ColumnMode = ColumnMode.force;

  educatorTeachingOverview$: Observable<ISubjectOverview[]>;

  constructor(private educatorTeachingOverviewService: EducatorTeachingOverviewService) { 
  }

  ngOnInit(): void {    
    this.educatorTeachingOverview$ = this.educatorTeachingOverviewService.educatorTeachingOverview$;
  }

  applySelectedDateRange() {
    this.lastAppliedDateRange = {
      fromDate: this.fromDateControl.value,
      toDate: this.toDateControl.value
    };

    this.educatorTeachingOverviewService.selectedDateRangeChanged(this.lastAppliedDateRange);
  }

  toggleExpandRow(row) {
    this.table.rowDetail.toggleExpandRow(row);
  }
}

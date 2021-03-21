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
  private defaultFromDate = this.educatorTeachingOverviewService.defaultFromDate;
  private defaultToDate = this.educatorTeachingOverviewService.defaultToDate;

  @ViewChild('fromPicker') fromPicker: any;
  @ViewChild('toPicker') toPicker: any;

  minDate: moment.Moment;
  maxDate: moment.Moment;
  dateTimePickerColour: ThemePalette = 'primary';
  fromDateControl = new FormControl(this.defaultFromDate);
  toDateControl = new FormControl(this.defaultToDate);

  gridColumnMode: ColumnMode = ColumnMode.force;
  
  columns = [
    { prop: 'subject' },
    { prop: 'uniqueExercises' }, 
    { prop: 'totalAnswers' },
    { prop: 'assessedSkillLevelChange' },
    { prop: 'totalReanswered' },
    { prop: 'totalReansweredPercentage', name: 'Total Reanswered %' },
  ];

  educatorTeachingOverview$: Observable<ISubjectOverview[]>;

  constructor(private educatorTeachingOverviewService: EducatorTeachingOverviewService) { 
  }

  ngOnInit(): void {    
    moment.locale('nl');
    console.log(moment.locale());
    this.educatorTeachingOverview$ = this.educatorTeachingOverviewService.educatorTeachingOverview$;
  }

  applySelectedDateRange() {
    this.educatorTeachingOverviewService.selectedDateRangeChanged({
      fromDate: this.fromDateControl.value,
      toDate: this.toDateControl.value
    });
  }
}

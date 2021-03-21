import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable'
import { EducatorTeachingOverviewService } from './educator-teaching-overview.service';
import { Observable } from 'rxjs';
import { ISubjectOverview } from '../models/subject-overview.model';

@Component({
  selector: 'app-educator-teaching-overview',
  templateUrl: './educator-teaching-overview.component.html',
  styleUrls: ['./educator-teaching-overview.component.scss']
})
export class EducatorTeachingOverviewComponent implements OnInit {
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
    const startDate = new Date(2015, 2, 24);
    const endDate = new Date(2015, 2, 24, 11, 30);

    this.educatorTeachingOverview$ = this.educatorTeachingOverviewService.get(startDate, endDate);
  }
}

import {Component, Input} from '@angular/core';
import {Data, UserId} from './data';
import {MatTableDataSource} from "@angular/material/table";

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent {
  @Input() data: Data[] = [];

  readonly displayedColumns = [
    'UserId',
    'Domain',
    'Subject',
    'ExerciseId',
    'LearningObjective',
    'Difficulty',
    'SubmittedAnswerId',
    'Correct',
    'Progress',
    'SubmitDateTime',
  ]
}

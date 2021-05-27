import {AfterViewInit, Component, Input, OnChanges, SimpleChanges, ViewChild} from "@angular/core";
import {Data, UserId} from "./data";
import {MatTableDataSource} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements AfterViewInit, OnChanges {
  @Input() data: Data[] = [];
  @ViewChild(MatSort) sort: MatSort | null = null;

  public dataSource = new MatTableDataSource<Data>([]);

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
  ];

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  ngOnChanges(changes: SimpleChanges) {
    if ('data' in changes) {
      this.dataSource.data = this.data;
    }
  }
}

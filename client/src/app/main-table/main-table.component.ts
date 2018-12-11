import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { MainTableDataSource } from './main-table-datasource';

@Component({
  selector: 'app-main-table',
  templateUrl: './main-table.component.html',
  styleUrls: ['./main-table.component.scss']
})
export class MainTableComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MainTableDataSource;

  columnDefs = [
    { headerName: 'Id', field: 'Id' },
    { headerName: 'NoOfExercise', field: 'NoOfExercise', width: 150 },
    { headerName: 'NoOfAttempts', field: 'NoOfAttempts' },
    { headerName: 'RightAttemptCount', field: 'RightAttemptCount', width: 90 },
    { headerName: 'Progress', field: 'Progress', width: 90 }
  ];

  @Input()
  public rowData: any;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    'Id',
    'NoOfExercise',
    'NoOfAttempts',
    'RightAttemptCount',
    'Progress'
  ];

  constructor() {}

  ngOnInit() {
    this.dataSource = new MainTableDataSource(
      this.paginator,
      this.sort,
      this.rowData
    );
  }
}

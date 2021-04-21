import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {TableStudent} from "@overview/interfaces/table-student.interface";
import {UsersTableSorter} from "@overview/interfaces/users-table-sort.interface";

@Component({
  selector: 'app-students-table',
  templateUrl: './students-table.component.html',
  styleUrls: ['./students-table.component.scss']
})
export class StudentsTableComponent implements OnInit, OnChanges {
  @Input() students: TableStudent[] = []
  dataSource = new MatTableDataSource<TableStudent>([]);
  displayedColumns = ['id', 'name', 'correctAnswers'];

  sorting: UsersTableSorter = {
    id: 'default',
    correctAnswers: 'default',
    name: 'default'
  };

  constructor() { }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.students) {
      Object.keys(this.sorting).forEach((el) => {
        this.sorting[el] = 'default';
      });
      this.dataSource.data = this.students;
    }
  }

  ngOnInit(): void {
  }

  filterData(field: string) {
    let sortType = 1;
    if (this.sorting[field] === 'default' || this.sorting[field] === 'asc'){
      this.sorting[field] = 'desc';
    } else {
      this.sorting[field] = 'asc';
      sortType = -1;
    }
    Object.keys(this.sorting).forEach((el) => {
      if (el !== field){
        this.sorting[el] = 'default';
      }
    });
    this.dataSource.data = [...this.dataSource.data].sort((a, b) => (a[field] > b[field] ? -sortType : sortType));
  }

}

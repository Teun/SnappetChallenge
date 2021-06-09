import {AfterViewInit, Component, Input, OnChanges, SimpleChanges, ViewChild} from "@angular/core";
import {MatSort} from "@angular/material/sort";
import {MatTableDataSource} from "@angular/material/table";
import {TableRow} from "../../interfaces/table-row";

@Component({
  selector: 'app-answers',
  templateUrl: './answers.component.html',
  styleUrls: ['./answers.component.css'],
})
export class AnswersComponent implements AfterViewInit, OnChanges {
  @Input() rows: TableRow[] | null = [];
  @ViewChild(MatSort) sort: MatSort | null = null;

  public dataSource = new MatTableDataSource<TableRow>([]);

  readonly displayedColumns = [
    'Name',
    'Answers',
    'Performance'
  ];

  ngAfterViewInit() {
    this.dataSource.sortingDataAccessor = (item, property: string) => {
      switch (property) {
        case 'Name':
          return item.userName;
        case 'Answers':
          return this.performance(item) || 0;
      }

      return '';
    };
    this.dataSource.sort = this.sort;
  }

  ngOnChanges(changes: SimpleChanges) {
    if ('rows' in changes) {
      if (this.rows != null) {
        this.dataSource.data = this.rows;
      }
    }
  }

  public performance(row: TableRow) {
    if (row.answers.length === 0) {
      return null;
    }

    const correct = row.answers.filter(answer => answer.correct === 1).length;
    return correct / row.answers.length
  }
}

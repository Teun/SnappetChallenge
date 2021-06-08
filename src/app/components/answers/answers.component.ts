import {AfterViewInit, Component, Input, OnChanges, SimpleChanges, ViewChild} from "@angular/core";
import {allLearningObjectives, Answer, LearningObjective, UserId} from "../../models/answer";
import {MatSort} from "@angular/material/sort";
import {MatTableDataSource} from "@angular/material/table";

export interface TableAnswer {
  correct: 0 | 1;
  learningObjective: LearningObjective;
}

export interface Row {
  userId: UserId;
  userName: string;
  answers: TableAnswer[];
}

@Component({
  selector: 'app-answers',
  templateUrl: './answers.component.html',
  styleUrls: ['./answers.component.css'],
})
export class AnswersComponent implements AfterViewInit, OnChanges {
  @Input() rows: Row[] | null = [];
  @ViewChild(MatSort) sort: MatSort | null = null;

  public dataSource = new MatTableDataSource<Row>([]);

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

  public performance(row: Row) {
    if (row.answers.length === 0) {
      return null;
    }

    const correct = row.answers.filter(answer => answer.correct === 1).length;
    return correct / row.answers.length
  }
}

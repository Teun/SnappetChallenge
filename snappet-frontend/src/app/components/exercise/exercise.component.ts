import {Component, OnInit, ViewChild} from '@angular/core';
import {BaseHttpService} from '../../services/base-http.service';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {ITdDataTableColumn} from '@covalent/core/data-table';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.component.html',
  styleUrls: ['./exercise.component.scss']
})
export class ExerciseComponent implements OnInit {

  _baseUrl = 'http://localhost:3000';
  reports = [];
  day = '2015-03-24';
  shown_reports = [];

  @ViewChild('paginator') paginator: MatPaginator;
  exerciseColumns: ITdDataTableColumn[] = [
    {name: 'user_id', label: 'Student Name'},
    {name: 'progress', label: 'Progress'},
    {name: 'correct', label: 'Correct Answers'},
    {name: 'difficulty', label: 'Difficulty'},
  ];

  constructor(private httpService: BaseHttpService) { }

  ngOnInit(): void {
    this.filterChanged();
  }

  private filterChanged() {
    this.httpService.get(`${this._baseUrl}/exercise-reports?time=${this.day}`).subscribe(reports => {
      this.reports = reports;
      this.shown_reports = this.reports.slice(0, 10);
    });
  }

  pageChanged(event) {
    this.shown_reports = this.reports.slice(event.pageIndex * 10, (event.pageIndex + 1) * 10);
  }
}

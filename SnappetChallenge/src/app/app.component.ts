import { Component, OnInit } from '@angular/core';
import { StudentResults } from './models/student-results.model';
import { first } from 'rxjs';

import { DataStoreService } from './services/data-store.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'SnappetChallenge';

  // Progress = 0
  public unratedStudents: StudentResults[] = [];

  // Progress negative
  public strugglingStudents: StudentResults[] = [];

  // Progress positive
  public studentResults: StudentResults[] = [];

  constructor(
    private dataStoreService: DataStoreService
  ) {

  }

  public ngOnInit(): void {
    this.getStudentData();
  }

  private getStudentData(): void {
    this.dataStoreService.unratedStudentsObservable.pipe(first()).subscribe((response: any) => {
      this.unratedStudents = response;
    });

    this.dataStoreService.strugglingStudentsObservable.pipe(first()).subscribe((response: any) => {
      this.strugglingStudents = response;
    });

    this.dataStoreService.studentResultsObservable.pipe(first()).subscribe((response: any) => {
      this.studentResults = response;
    });
  }
}

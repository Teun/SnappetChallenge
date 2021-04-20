import {Component, OnDestroy, OnInit} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {TableStudent} from "@overview/interfaces/table-student.interface";
import {OverviewService} from "@core/services/overview.service";
import {StudentsService} from "@core/services/students.service";
import {switchMap, takeUntil} from "rxjs/operators";
import {ApiStudent} from "@shared/interfaces/api-student.interface";
import {Subject} from "rxjs";

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.scss']
})
export class StudentsListComponent implements OnInit, OnDestroy {
  dataSource = new MatTableDataSource<ApiStudent>([]);
  displayedColumns = ['id', 'name'];

  private unsubscribe = new Subject();

  constructor(
    private overviewService: OverviewService,
    private studentsService: StudentsService
  ) {
  }

  ngOnInit(): void {
    this.studentsService.fetchedStudents$
        .pipe(takeUntil(this.unsubscribe))
        .subscribe((students) => {
        this.dataSource.data = students;
      })

    this.studentsService.getStudents()
      .pipe(
        takeUntil(this.unsubscribe),
        switchMap(() => {
          return this.overviewService.getAnswers();
        }))
      .subscribe()
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

}

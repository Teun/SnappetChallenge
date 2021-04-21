import {Component, OnDestroy, OnInit} from '@angular/core';
import {OverviewService} from "@core/services/overview.service";
import {StudentsService} from "@core/services/students.service";
import {switchMap, takeUntil} from "rxjs/operators";
import {TableStudent} from "@overview/interfaces/table-student.interface";
import {ChartItem} from "@core/interfaces/chart-item.interface";
import {Subject} from "rxjs";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit, OnDestroy {

  students: TableStudent[] = [];
  difficultExercises: ChartItem[] = [];

  private unsubscribe = new Subject();

  constructor(
    private overviewService: OverviewService,
    private studentsService: StudentsService
  ) {}

  ngOnInit(): void {
    this.studentsService.usersTable$
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((data) => {
        this.students = data;
      });
    this.overviewService.mostDifficultExercises$
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((data) => {
        this.difficultExercises = data
          .sort((a, b) => (a.value > b.value ? -1 : 1))
          .slice(0, 5);
      })
    this.studentsService.getStudents()
      .pipe(
        switchMap(() => this.overviewService.getAnswers()),
        takeUntil(this.unsubscribe)
      )
      .subscribe();
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}

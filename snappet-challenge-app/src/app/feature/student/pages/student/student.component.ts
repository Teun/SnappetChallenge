import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {StudentsService} from "@core/services/students.service";
import {switchMap, takeUntil} from "rxjs/operators";
import {OverviewService} from "@core/services/overview.service";
import {of, Subject} from "rxjs";
import {ApiStudent} from "@core/interfaces/api-student.interface";
import {ChartItem} from "@core/interfaces/chart-item.interface";
import {ApiAnswer} from "@core/interfaces/api-answer.interface";

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit, OnDestroy {
  id: number;
  student?: ApiStudent;
  difficultSubjects: ChartItem[] = [];
  subjects: string[] = [];

  private unsubscribe = new Subject();

  constructor(
    activatedRoute: ActivatedRoute,
    router: Router,
    private studentsService: StudentsService,
    private overviewService: OverviewService
  ) {
    const id = activatedRoute?.snapshot?.params?.id;
    if (id && !isNaN(Number(id))){
      this.id = Number(id);

      this.overviewService.getStudentStatistics(this.id)
        .pipe(takeUntil(this.unsubscribe))
        .subscribe((data) => {
          const difficultSubjects = this.extractDifficultSubjects(data);
          this.difficultSubjects = difficultSubjects
            .sort((a, b) => (a.value > b.value ? -1 : 1))
            .slice(0, 5);
          this.subjects = difficultSubjects.map(el => el.name);
        })

    } else {
      router.navigate(['../../overview'], {relativeTo: activatedRoute});
    }
  }

  ngOnInit(): void {
    this.studentsService.getStudent(this.id)
      .pipe(
        takeUntil(this.unsubscribe),
        switchMap((data) => {
          if (data) {
            this.student = data;
            return this.overviewService.getAnswers()
          }
          return of(null);
        })
      )
      .subscribe()
  }

  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  private extractDifficultSubjects(data: ApiAnswer[]): ChartItem[] {
    const difficultSubjects: ChartItem[] = []
    data.forEach((answer) => {
      const index = difficultSubjects.findIndex((el) => el.name === answer.Subject);
      if (index !== -1 && !answer.Correct){
        difficultSubjects[index].value++
      } else if (index === -1){
        difficultSubjects.push({name: answer.Subject, value: 0});
      }
    });
    return difficultSubjects;
  }

}

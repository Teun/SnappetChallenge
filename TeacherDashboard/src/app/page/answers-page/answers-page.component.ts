import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { delay, map } from 'rxjs/operators';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { DataHolder } from '../../objects/data-holder';
import { Student } from '../../objects/student';
import { SubjectGroup } from '../../objects/subject-group';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-answers-page',
  templateUrl: './answers-page.component.html',
  styleUrls: ['./answers-page.component.scss']
})
export class AnswersPageComponent implements OnInit {
  public loading = true;

  private dataHolder!: Observable<DataHolder>;
  public groups!: Observable<Array<SubjectGroup>>;

  public chartColors = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataHolder = this.dataService.getAnswersForDate();
    this.groups = this.dataHolder
      .pipe(map(dataHolder => dataHolder.groups));

    const subscription = this.groups
      .pipe(delay(1))
      .subscribe(() => {
        this.loading = false;
        subscription.unsubscribe();
      });
  }

  public get struggling(): Observable<Student> {
    return this.dataHolder.pipe(
      map(dataHolder => dataHolder.students),
      map(students => students.sort((a, b) => a.progress - b.progress)),
      map(students => students[0])
    );
  }

  public get top(): Observable<Student> {
    return this.dataHolder.pipe(
      map(dataHolder => dataHolder.students),
      map(students => students.sort((a, b) => b.progress - a.progress)),
      map(students => students[0])
    );
  }

  public get chartValues(): Observable<Array<PieChartValue>> {
    return this.groups
      .pipe(
        map(data => data.map(item => ({
          name: item.subject,
          value: item.objectives.reduce((total, item) => total + item.answerCount, 0)
        })))
      );
  }
}

import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { delay, map } from 'rxjs/operators';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { Student } from '../../objects/student';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-users-page',
  templateUrl: './users-page.component.html',
  styleUrls: ['./users-page.component.scss']
})
export class UsersPageComponent implements OnInit {
  public loading = true;

  public students!: Observable<Array<Student>>;
  public student!: Student;

  public chartColors = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.students = this.dataService.getAnswersForDate()
      .pipe(map(dataHolder => dataHolder.students));

    const subscription = this.students
      .pipe(delay(1))
      .subscribe(() => {
        this.loading = false;
        subscription.unsubscribe();
      });
  }

  public get chartValues(): Observable<Array<PieChartValue>> {
    return this.students
      .pipe(
        map(data => data.map(item => ({
          name: item.id + "",
          value: item.answerCount
        })))
      );
  }
}

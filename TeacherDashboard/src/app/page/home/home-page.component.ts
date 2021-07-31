import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { delay, filter, map } from 'rxjs/operators';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { SubjectGroup } from '../../interfaces/subject-group';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  public loading = true;

  public subjectGroups!: Observable<Array<SubjectGroup>>;

  public chartColors = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };
  public chartValues!: Array<PieChartValue>;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.subjectGroups = this.dataService.getSubjectGroupsForDate();

    const subscription = this.subjectGroups
      .pipe(
        delay(1),
        filter(data => data.length > 0),
        map(data => data.map(item => ({
          name: item.subject,
          value: item.objectives.reduce((total, item) => total + item.answers, 0)
        })))
      )
      .subscribe(values => {
        this.chartValues = values;
        this.loading = false;
        subscription.unsubscribe();
      });
  }
}

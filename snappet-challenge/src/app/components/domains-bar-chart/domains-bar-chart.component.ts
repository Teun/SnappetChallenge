import { Component, Input } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { BehaviorSubject, combineLatest } from 'rxjs';
import { map, publishReplay, refCount, tap } from 'rxjs/operators';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-domains-bar-chart',
  templateUrl: './domains-bar-chart.component.html',
  styleUrls: ['./domains-bar-chart.component.css'],
})
export class DomainsBarChartComponent {
  selectedSubject = new BehaviorSubject('');
  selectedDomain = new BehaviorSubject('');
  selectedDate$ = this.dataService.selectedDate$;

  dataset: ChartDataSets[] = [];
  labels: Label[] = [];

  //Data source
  subjectData$ = this.dataService.processedData$;
  domainData$ = combineLatest([this.subjectData$, this.selectedSubject]).pipe(
    map(([data, selectedSubject]) => {
      if (selectedSubject && data[selectedSubject]) {
        return data[selectedSubject].domains;
      } else {
        const firstSubject = Object.keys(data)[0];
        return data[firstSubject].domains;
      }
    }),
    publishReplay(1),
    refCount()
  );
  objectivesData$ = combineLatest([this.domainData$, this.selectedDomain]).pipe(
    map(([data, selectedDomain]) => {
      if (selectedDomain && data[selectedDomain]) {
        return data[selectedDomain].objectives;
      } else {
        const firstDomain = Object.keys(data)[0];
        return data[firstDomain].objectives;
      }
    }),
    tap((data) => {
      this.dataset = [
        {
          data: Object.entries(data).map(([key, value]) => value.count),
          label: '',
        },
      ];
      this.labels = Object.entries(data).map(
        ([key, value]) => `${key} - ${value.count}`
      );
    }),
    publishReplay(1),
    refCount()
  );

  //Options for displaying the bar chart
  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartType: ChartType = 'bar';
  public barChartLegend = false;
  public barChartPlugins = [];

  constructor(private dataService: DataService) {}

  onSubjectSelected(value: string) {
    this.selectedSubject.next(value);
    this.selectedDomain.next('');
  }
  onDomainSelected(value: string) {
    this.selectedDomain.next(value);
  }
}

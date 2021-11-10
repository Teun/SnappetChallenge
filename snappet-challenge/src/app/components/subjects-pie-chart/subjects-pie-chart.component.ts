import { Component } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet, Label } from 'ng2-charts';
import { tap } from 'rxjs/operators';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-subjects-pie-chart',
  templateUrl: './subjects-pie-chart.component.html',
  styleUrls: ['./subjects-pie-chart.component.css'],
})
export class SubjectsPieChartComponent {
  // Options for rendering the pie chart
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];

  public dataset: SingleDataSet = [];
  public labels: Label[] = [];

  //Data source
  selectedDate$ = this.dataService.selectedDate$;
  subjectData$ = this.dataService.processedData$.pipe(
    tap((data) => {
      this.dataset = Object.values(data).map((value) => value.count);
      this.labels = Object.entries(data).map(
        ([key, value]) => `${key} - ${value.count}`
      );
    })
  );

  constructor(private dataService: DataService) {}
}

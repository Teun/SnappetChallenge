import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-doughnut-chart',
  templateUrl: './doughnut-chart.component.html',
  styleUrls: ['./doughnut-chart.component.scss']
})
export class DoughnutChartComponent implements OnInit {
  constructor() {}

  public pieChartLabels: string[] = ['Correct', 'InCorrect'];
  public pieChartData: number[] = [70, 30];
  public pieChartType = 'pie';
  public pieChartOptions: any = {
    backgroundColor: ['#FF6384', '#4BC0C0']
  };

  @Input()
  public data: any;

  @Input()
  public type: any;

  // tslint:disable-next-line:no-output-on-prefix
  @Output()
  public onchartClicked = new EventEmitter();

  ngOnInit() {
    this.pieChartData = [
      this.data.CorrectAttempts,
      this.data.IncorrectAttempts
    ];
  }

  public chartClicked(e: any): void {
    console.log(e);
    this.onchartClicked.emit({ key: this.data.Key, type: this.type });
  }

}

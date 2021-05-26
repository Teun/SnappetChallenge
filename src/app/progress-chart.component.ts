import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-progress-chart',
  templateUrl: './progress-chart.component.html',
  styleUrls: ['progress-chart.component.css']
})
export class ProgressChart {
  @Input() single: { name: string, value: number }[] = [];
}

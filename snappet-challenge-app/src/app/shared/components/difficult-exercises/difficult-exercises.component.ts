import {Component, Input} from '@angular/core';
import {ChartItem} from "@shared/interfaces/chart-item.interface";

@Component({
  selector: 'app-difficult-exercises',
  templateUrl: './difficult-exercises.component.html',
  styleUrls: ['./difficult-exercises.component.scss']
})
export class DifficultExercisesComponent {
  @Input() data: ChartItem[] = []
  @Input() xAxisLabel = '';
  @Input() yAxisLabel = '';

  view: [first: number, second: number] = [700, 400];

  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  showYAxisLabel = true;

  constructor() {
  }

}

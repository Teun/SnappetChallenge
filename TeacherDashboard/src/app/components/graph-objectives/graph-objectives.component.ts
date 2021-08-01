import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { Objective } from '../../objects/objective';

@Component({
  selector: 'app-graph-objectives',
  templateUrl: './graph-objectives.component.html',
  styleUrls: ['./graph-objectives.component.scss']
})
export class GraphObjectivesComponent {
  @Input()
  public objectives!: Array<Objective>;

  @Output()
  public onSelect: EventEmitter<string> = new EventEmitter();

  public get chartValues(): Array<PieChartValue> {
    return this.objectives
      .map(item => ({
        name: item.objective,
        value: item.answerCount
      }))
      .sort((a, b) => b.value - a.value);
  }
}

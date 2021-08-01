import { Component, Input } from '@angular/core';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { SubjectGroup } from '../../objects/subject-group';

@Component({
  selector: 'app-graph-subject-groups',
  templateUrl: './graph-subject-groups.component.html',
  styleUrls: ['./graph-subject-groups.component.scss']
})
export class GraphSubjectGroupsComponent {
  @Input()
  public groups!: Array<SubjectGroup>;

  public get chartValues(): Array<PieChartValue> {
    return this.groups.map(item => ({
      name: item.subject,
      value: item.objectives.reduce((total, item) => total + item.answerCount, 0)
    }));
  }
}

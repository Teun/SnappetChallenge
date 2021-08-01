import { Component, Input } from '@angular/core';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { SubjectGroup } from '../../objects/subject-group';

@Component({
  selector: 'app-list-subject-groups',
  templateUrl: './list-subject-groups.component.html',
  styleUrls: ['./list-subject-groups.component.scss']
})
export class ListSubjectGroupsComponent {
  @Input()
  public groups!: Array<SubjectGroup>;
  public expandedPanel = -1;

  public getChartValues(group: SubjectGroup): Array<PieChartValue> {
    return group.objectives
      .map(item => ({
        name: item.objective,
        value: item.answerCount
      }))
      .sort((a, b) => b.value - a.value);
  }

  public onSelect(name: string, item: SubjectGroup) {
    this.expandPanel(item.objectives.findIndex(objective => objective.objective === name));
  }

  public expandPanel(index: number) {
    this.expandedPanel = index;
  }
}

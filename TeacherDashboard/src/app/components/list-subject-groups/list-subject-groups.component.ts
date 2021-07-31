import { Component, Input } from '@angular/core';
import { Excercise } from '../../interfaces/excercise';
import { PieChartValue } from '../../interfaces/pie-chart-value';
import { SubjectGroup } from '../../interfaces/subject-group';
import { average } from '../../utils/average';

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
        value: item.answers
      }))
      .sort((a, b) => b.value - a.value);
  }

  public progress(excercises: Array<Excercise>): number {
    return average(excercises.map(item => average(item.progress)));
  }

  public onSelect(event: { name: string }, item: SubjectGroup) {
    this.expandedPanel = item.objectives.findIndex(objective => objective.objective === event.name);
  }
}

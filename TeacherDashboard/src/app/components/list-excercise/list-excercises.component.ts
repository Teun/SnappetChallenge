import { Component, Input } from '@angular/core';
import { Excercise } from '../../interfaces/excercise';
import { average } from '../../utils/average';

@Component({
  selector: 'app-list-excercises',
  templateUrl: './list-excercises.component.html',
  styleUrls: ['./list-excercises.component.scss']
})
export class ListExcercisesComponent {
  @Input()
  public excercises!: Array<Excercise>;

  public displayedColumns: string[] = ['id', 'submissions', 'difficulty', 'progress'];

  public average(values: Array<number>): number | string {
    if (!values.length) {
      return "";
    }

    return average(values);
  }

  public parseDifficulty(value: string): string {
    return Number.isNaN(Number.parseFloat(value)) ? "" : value;
  }
}

import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-subject-chart',
  templateUrl: './subject-chart.component.html',
  styleUrls: ['subject-chart.component.css']
})
export class SubjectChart {
  @Input() single: { name: string, value: number }[] = [];
}

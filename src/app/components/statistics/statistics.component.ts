import {Component, Input} from "@angular/core";

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css'],
})
export class StatisticsComponent {
  @Input() students: number | null = 0;
  @Input() answers: number | null = 0;
}

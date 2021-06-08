import {Component, Input} from "@angular/core";

@Component({
  selector: 'app-performance-indicator',
  templateUrl: './performance-indicator.component.html',
  styleUrls: ['./performance-indicator.component.css'],
})
export class PerformanceIndicatorComponent {
  @Input() performance: number | null = null;
}

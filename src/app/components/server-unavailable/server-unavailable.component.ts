import {Component, Input} from "@angular/core";

@Component({
  selector: 'app-server-unavailable',
  templateUrl: './server-unavailable.component.html',
  styleUrls: ['./server-unavailable.component.css'],
})
export class ServerUnavailableComponent {
  @Input() answers: number | null = 0;
}

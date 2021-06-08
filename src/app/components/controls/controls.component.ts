import {Component} from "@angular/core";
import {ControlsService, ControlsState} from "../../services/controls.service";

@Component({
  selector: 'app-controls',
  templateUrl: './controls.component.html',
  styleUrls: ['./controls.component.css'],
})
export class ControlsComponent {
  constructor(public controlsService: ControlsService) {
  }

  onPlay() {
    this.controlsService.state.next(ControlsState.Play);
  }

  onPause() {
    this.controlsService.state.next(ControlsState.Pause);
  }

  onStop() {
    this.controlsService.state.next(ControlsState.Stop);
  }

  get isPlay() {
    return this.controlsService.state.value === ControlsState.Play;
  }

  get isPause() {
    return this.controlsService.state.value === ControlsState.Pause;
  }

  get isStop() {
    return this.controlsService.state.value === ControlsState.Stop;
  }
}

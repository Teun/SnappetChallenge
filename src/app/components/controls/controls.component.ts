import {Component} from "@angular/core";
import {Store} from "@ngrx/store";
import {selectControlState} from "../../ngrx/answers.reducer";
import {changeControlState} from "../../ngrx/answers.actions";
import {map} from "rxjs/operators";
import {ControlsState} from "../../interfaces/controls-state";
import {State} from "../../interfaces/state";

@Component({
  selector: 'app-controls',
  templateUrl: './controls.component.html',
  styleUrls: ['./controls.component.css'],
})
export class ControlsComponent {
  constructor(public store: Store<State>) {
  }

  onPlay() {
    this.store.dispatch(changeControlState({ controlState: ControlsState.Play }));
  }

  onPause() {
    this.store.dispatch(changeControlState({ controlState: ControlsState.Pause }));
  }

  onStop() {
    this.store.dispatch(changeControlState({ controlState: ControlsState.Stop }));
  }

  get isPlay() {
    return this.store.select(selectControlState).pipe(map(state => state === ControlsState.Play));
  }

  get isPause() {
    return this.store.select(selectControlState).pipe(map(state => state === ControlsState.Pause));
  }

  get isStop() {
    return this.store.select(selectControlState).pipe(map(state => state === ControlsState.Stop));
  }
}

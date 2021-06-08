import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";

export enum ControlsState {
  Play,
  Pause,
  Stop,
}

@Injectable({
  providedIn: 'root',
})
export class ControlsService {
  readonly state = new BehaviorSubject(ControlsState.Stop);
}

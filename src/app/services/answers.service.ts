import {Injectable} from "@angular/core";
import {Answer} from "../models/answer";
import {Socket} from "ngx-socket-io";
import {shareReplay, tap} from "rxjs/operators";
import {ControlsService, ControlsState} from "./controls.service";

@Injectable({
  providedIn: 'root',
})
export class AnswersService {
  readonly answer$ = this.socket.fromEvent<Answer>('message').pipe(
    shareReplay(1),
  );

  readonly toggle = this.controlsService.state.pipe(
    tap(state => {
      if (state === ControlsState.Stop) {
        this.socket.disconnect();
      } else {
        this.socket.connect();
      }
    })
  ).subscribe();

  constructor(
    private socket: Socket,
    public controlsService: ControlsService
  ) {
  }

}

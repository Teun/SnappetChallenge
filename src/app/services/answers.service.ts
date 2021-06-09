import {Injectable} from "@angular/core";
import {Answer} from "../models/answer";
import {Socket} from "ngx-socket-io";

@Injectable({
  providedIn: 'root',
})
export class AnswersService {
  constructor(public socket: Socket) {
  }

  getAnswers() {
    return this.socket.fromEvent<Answer>('message');
  }
}

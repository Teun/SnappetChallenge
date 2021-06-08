import {Component, Input} from "@angular/core";
import {TableAnswer} from "../answers/answers.component";

@Component({
  selector: 'app-answer-emoticons',
  templateUrl: './answer-emoticons.component.html',
  styleUrls: ['./answer-emoticons.component.css'],
})
export class AnswerEmoticonsComponent {
  @Input() answers: TableAnswer[] = [];
}

import {Component, Input} from "@angular/core";
import {TableAnswer} from "../../interfaces/table-row";

@Component({
  selector: 'app-answer-emoticons',
  templateUrl: './answer-emoticons.component.html',
  styleUrls: ['./answer-emoticons.component.css'],
})
export class AnswerEmoticonsComponent {
  @Input() answers: TableAnswer[] = [];
}

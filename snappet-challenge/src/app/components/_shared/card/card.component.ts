import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {ButtonToggleModel} from "../../../models/button-toggle.model";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent{
  @Input() state: string;
  @Input() title: string;
  @Input() subTitle: string;
  @Input() buttonToggleValues: Array<ButtonToggleModel>;

  @Output() eventEmitter = new EventEmitter;

  compareToGroup: FormGroup;
  compareToControl = new FormControl(null);

  constructor() {
    this.compareToGroup = new FormGroup({
      compareToControl: this.compareToControl
    });
  }

  onChange(): void {
      this.eventEmitter.emit(this.compareToControl.value);
  }

}

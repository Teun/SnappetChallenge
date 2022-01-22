import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {ButtonToggleModel} from "../../../models/button-toggle.model";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input() state: string;
  @Input() title: string;
  @Input() subTitle: string;
  @Input() buttonToggleValues: Array<ButtonToggleModel>;

  @Output() eventEmitter = new EventEmitter;

  compareToGroup: FormGroup;
  compareToControl = new FormControl(null);

  compareSubscription: Subscription;


  constructor() {
    this.compareToGroup = new FormGroup({
      compareToControl: this.compareToControl
    });
  }

  ngOnInit(): void {
    this.compareSubscription = this.compareToControl.valueChanges.subscribe(value => {
      this.eventEmitter.emit(value);
    })
  }

}

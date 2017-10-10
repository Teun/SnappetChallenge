import { Component, Output, EventEmitter } from '@angular/core';

import { CurrentDateService } from '../../services/currentDateService';

@Component({
  selector: 'date-selector',
  templateUrl: 'date-selector.html'
})
export class DateSelectorComponent {

  @Output() dateChanged = new EventEmitter<void>();

  constructor(private currentDateService: CurrentDateService) {

  }

  changeDate(change: number) {
    this.currentDateService.addDays(change);
    this.dateChanged.emit();
  }
}
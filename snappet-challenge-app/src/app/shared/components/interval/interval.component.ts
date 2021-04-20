import { Component, OnInit } from '@angular/core';
import {IntervalSelectItem} from "@overview/classes/interval-select-item";
import {MatSelectChange} from "@angular/material/select";
import {IntervalService} from "@core/services/interval.service";
import {BehaviorSubject} from "rxjs";
import {addDaysToDate} from "@shared/helpers/date-time.helper";

@Component({
  selector: 'app-interval',
  templateUrl: './interval.component.html',
  styleUrls: ['./interval.component.scss']
})
export class IntervalComponent implements OnInit {
  from = new Date();
  to = new Date();

  intervals: IntervalSelectItem[] = [];
  selectedInterval?: IntervalSelectItem;

  dateChanged = new BehaviorSubject(false);

  constructor(private intervalService: IntervalService) {
    this.intervals = intervalService.intervals;
    this.from = intervalService.filter$.value.from;
    this.to = intervalService.filter$.value.to;
  }

  ngOnInit(): void {
    this.intervalService.selectedInterval$.subscribe((selectedItem) => {
      this.selectedInterval = selectedItem;
    });
    this.dateChanged.subscribe(() => {
      if (this.to){
        this.intervalService.setFilter({from: this.from, to: addDaysToDate(this.to, 1)});
      }
    })
  }

  onDateChange() {
    this.dateChanged.next(true);
  }

  onIntervalChange(event: MatSelectChange) {
    if (event.value.value !== 'custom'){
      this.from = event.value.from;
      this.to = event.value.to;
      this.dateChanged.next(true);
    }
    this.intervalService.setSelectedInterval(event.value.value);
  }

}

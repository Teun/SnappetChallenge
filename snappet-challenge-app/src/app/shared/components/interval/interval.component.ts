import {Component, OnDestroy, OnInit} from '@angular/core';
import {IntervalSelectItem} from "@overview/classes/interval-select-item";
import {MatSelectChange} from "@angular/material/select";
import {IntervalService} from "@core/services/interval.service";
import {BehaviorSubject, Subject} from "rxjs";
import {addDaysToDate} from "@shared/helpers/date-time.helper";
import {takeUntil} from "rxjs/operators";

@Component({
  selector: 'app-interval',
  templateUrl: './interval.component.html',
  styleUrls: ['./interval.component.scss']
})
export class IntervalComponent implements OnInit, OnDestroy {
  from = new Date();
  to = new Date();

  intervals: IntervalSelectItem[] = [];
  selectedInterval?: IntervalSelectItem;

  dateChanged = new BehaviorSubject(false);

  private unsubscribe = new Subject();

  constructor(private intervalService: IntervalService) {
    this.intervals = intervalService.intervals;
    this.from = intervalService.filterValue.from;
    this.to = intervalService.filterValue.to;
  }

  ngOnInit(): void {
    this.intervalService.selectedInterval$
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((selectedItem) => {
        this.selectedInterval = selectedItem;
      });
    this.dateChanged
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {
        if (this.to){
          this.intervalService.setFilter({from: this.from, to: addDaysToDate(this.to, 1)});
        }
      })
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
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

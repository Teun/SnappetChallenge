import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {OverviewFilter} from "@overview/interfaces/overview-filter.interface";
import {IntervalSelectItem} from "@overview/classes/interval-select-item";

@Injectable({
  providedIn: 'root'
})
export class IntervalService {
  today = new Date('2015-03-24 11:30:00');
  intervals: IntervalSelectItem[] = [
    new IntervalSelectItem('Today', 'today', this.today),
    new IntervalSelectItem('Last 7 days', 'last7', this.today, 7),
    new IntervalSelectItem('Last 30 days', 'last30', this.today, 30),
    new IntervalSelectItem('Custom', 'custom', this.today),
  ];

  selectedInterval$ = new BehaviorSubject<IntervalSelectItem>(this.intervals[0]);
  filter$ = new BehaviorSubject<OverviewFilter>({
    from: new Date('2015-03-24 00:00:00'),
    to: this.today
  });
  constructor() {}

  setSelectedInterval(value: string) {
    this.selectedInterval$.next(this.intervals.find(el => el.value === value) || this.selectedInterval$.value);
  }

  setFilter(filter: OverviewFilter) {
    this.filter$.next({...filter});
  }
}

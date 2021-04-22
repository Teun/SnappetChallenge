import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {FilterState, Work, Store} from "./models";
import {BehaviorSubject} from "rxjs";
import {map, tap} from "rxjs/operators";
import {getChartDataByFilter, initFilter} from "./utils";

const initial: Store = {
  isLoading: false,
  works: [],
  chartData: undefined,
  filterState: {
    UserId: null,
    Subject: null,
    Domain: null,
    LearningObjective: null,
  },
  filterValues: {
    users: [],
    subject: [],
    domain: [],
    learningObjective: []
  }
}

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  store: BehaviorSubject<Store> = new BehaviorSubject(initial);

  constructor(private httpClient: HttpClient) {
  }

  get filterValues() {
    return this.store.pipe(map(data => data.filterValues))
  }

  get filterState() {
    return this.store.pipe(map(data => data.filterState))
  }

  get chartData() {
    return this.store.pipe(map(data => data.chartData))
  }

  get isLoading() {
    return this.store.pipe(map(data => data.isLoading))
  }

  updateFilterState(value: Partial<FilterState>) {
    const store = this.store.getValue();
    const filterState = {...store.filterState, ...value};
    const chartData = getChartDataByFilter(store.works, filterState);
    this.store.next({...store, filterState, chartData})
  }

  requestWorks() {
    const store = this.store.getValue();
    this.store.next({...store, isLoading: true});
    this.httpClient.get<Work[]>('./assets/work.json').pipe(
      map(works => works.filter(work => new Date(work.SubmitDateTime).getTime() < new Date('2015-03-24T11:30:00').getTime())),
      tap(works => {
        const filterValues = initFilter(works)
        const chartData = getChartDataByFilter(works, store.filterState);
        this.store.next({...store, works, isLoading: false, filterValues, chartData})
      })
    ).subscribe();
  }
}

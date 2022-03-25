import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Domains, RawData, Subjects } from '../models/class.model';
import { domainsFromService } from '../utils/mappers';
import { sortByDate } from '../utils/sorters';

@Injectable({
  providedIn: 'root',
})
export class DataHttpService {
  _cachedData$: Observable<Subjects>;
  constructor(private readonly httpService: HttpClient) {}

  getClassData(): Observable<Subjects> {
    if (!this._cachedData$) {
      this._cachedData$ = this.httpService.get('../../assets/work.json').pipe(
        map((items: RawData[]) => {
          return items.map((i) => (i.Domain === '-' ? { ...i, Domain: 'noDomain' } : i));
        }),
        map(sortByDate),
        map(domainsFromService),
        shareReplay(1)
      );
    }

    return this._cachedData$;
  }
}

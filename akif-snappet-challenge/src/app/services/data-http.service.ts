import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Domains, RawData } from '../models/class.model';
import { domainsFromService } from '../utils/mappers';

@Injectable({
  providedIn: 'root',
})
export class DataHttpService {
  constructor(private readonly httpService: HttpClient) {}

  getClassData() {
    return this.httpService.get('../../assets/work.json').pipe(
      map((items: RawData[]) => {
        return items.map((i) =>
          i.Domain === '-' ? { ...i, Domain: 'others' } : i
        );
      }),
      map(domainsFromService)
    );
  }
}

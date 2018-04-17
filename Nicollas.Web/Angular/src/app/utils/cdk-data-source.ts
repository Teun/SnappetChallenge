import {DataSource} from '@angular/cdk';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/observable/fromEvent';
import { Subscription } from 'rxjs/Subscription';

/**
 * Data source to provide what data should be rendered in the table. Note that the data source
 * can retrieve its data in any way. In this case, the data source is provided a reference
 * to a common data base, ExampleDatabase. It is not the data source's responsibility to manage
 * the underlying data. Instead, it only needs to take the data and send the table exactly what
 * should be rendered.
 */
export class CdkDataSource<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey>
        extends DataSource<any> {
  _filterChange = new BehaviorSubject(this.defaultFilterFunction);
  get filter(): (row: TEntity) => boolean { return this._filterChange.value; }
  set filter(filter: (row: TEntity) => boolean ) { this._filterChange.next(filter); }

  private data = new BehaviorSubject<TEntity[]>([]);
  private subscribed: Subscription;
  constructor(private paramRec: Observable<TEntity[]>) {
    super();
    this.subscribed = paramRec.subscribe(data => {
      this.data.next(data)
    });
  }

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<TEntity[]> {
    const displayDataChanges = [
      this.data,
      this._filterChange,
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      return this.data.value.slice().filter(this._filterChange.value);
    });
  }

  disconnect() { }

  private defaultFilterFunction(row: TEntity): boolean { return true }
}

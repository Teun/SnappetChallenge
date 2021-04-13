import { Component, OnInit } from '@angular/core';
import { Actions, ofType } from '@ngrx/effects';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map, tap } from 'rxjs/operators';
import { GraphData } from 'src/app/core/model/graphdata';
import { PlotGraphService } from 'src/app/core/services/plotgraph/plot-graph.service';
import { AppState } from 'src/app/store/reducer';
import { selectAllOverview } from '../store/overview.selectors';

@Component({
  selector: 'app-my-class-page-layout',
  templateUrl: './my-class-page-layout.component.html',
  styleUrls: ['./my-class-page-layout.component.scss']
})
export class MyClassPageLayoutComponent implements OnInit {

  /* This observable has the GraphData which is subscribed in the template for dispalying graph*/
  chartGraphsData$: Observable<GraphData>;

  /* Conatins the raw Data retreived from the selector - selectAllOverview*/
  overviewRawData: any;

  constructor(private store: Store<AppState>, private plotGraphService: PlotGraphService) { }

  ngOnInit(): void {
    /* Observable assigned to listen the Replay Subject*/
    this.chartGraphsData$ = this.plotGraphService.graphData$;

    /* Subscribe to the NgRx Store
    ` - for retreving the raw Data from the Selector and assign to overviewRawData
      - Invoke the plotGraphService which has all the business logic to populate the different charts in dashboard
    */
    this.store.pipe(
      select(selectAllOverview),
      filter(data => Object.keys(data).length > 0),
      tap(data => this.overviewRawData = data),
      map(data => this.plotGraphService.plotChartData(data, ['2015-03-24']))
    ).subscribe();
  }

  /* Listen to the child component event on change of date dropdown*/
  latestDropDownValue(value: string): void{
    this.plotGraphService.plotChartData(this.overviewRawData, [value]);
  }

}

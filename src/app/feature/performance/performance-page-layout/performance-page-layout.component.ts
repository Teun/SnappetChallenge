import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, tap } from 'rxjs/operators';
import { GraphData } from 'src/app/core/model/graphdata';
import { PlotGraphService } from 'src/app/core/services/plotgraph/plot-graph.service';
import { AppState } from 'src/app/store/reducer';
import { selectAllOverview } from '../../my-class/store/overview.selectors';

@Component({
  selector: 'app-performance-page-layout',
  templateUrl: './performance-page-layout.component.html',
  styleUrls: ['./performance-page-layout.component.scss']
})
export class PerformancePageLayoutComponent implements OnInit {

  chartGraphsData$: Observable<GraphData>;
  overviewRawData!: any;

  constructor(private store: Store<AppState>,
              private plotGraphService: PlotGraphService) { }

  ngOnInit(): void {
    this.chartGraphsData$ = this.plotGraphService.graphData$;

    /* Subscribe to the NgRx Store
    ` - for retreving the raw Data from the Selector and assign to overviewRawData
      - this data is only used for the new dates in the DropDown
    */
    this.store.pipe(
      select(selectAllOverview),
      filter(data => Object.keys(data).length > 0),
      tap(data => this.overviewRawData = data)
    ).subscribe();
  }

  latestDropDownValue(value: string): void{
    this.plotGraphService.plotChartData(this.overviewRawData, [value]);
  }

}

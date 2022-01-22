import {Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {Subscription} from "rxjs";
import {ResultsModel} from "../../../models/results.model";
import {calculateMinusDays, MomentCalculateUtil} from "../../utils/moment-calculate.util";
import {LabelTranslationModel} from "../../../models/label-translation.model";
import {ChartModel} from "../../../models/chart.model";
import {getResults} from "../../utils/date.utils";
import {DateModel} from "../../../models/date.model";
import {ButtonToggleModel} from "../../../models/button-toggle.model";

@Component({
  selector: 'app-class-results',
  templateUrl: './class-results.component.html',
  styleUrls: ['./class-results.component.scss']
})
export class ClassResultsComponent implements OnInit, OnChanges {
  @Input() state: string;
  @Input() results: Array<ResultsModel>;
  @Input() resultsToday: Array<ResultsModel>;
  @Input() dataTimesToday: DateModel;

  @Output() eventEmitter = new EventEmitter;

  chartData: Array<ChartModel>;

  subjects: Array<string>;

  buttonToggleValues: Array<ButtonToggleModel>;

  constructor() {
  }

  ngOnInit() {
    this.buttonToggleValues = [
      {value: 'yesterday', label: 'Gisteren'},
      {value: 'previous-week', label: 'Vorige week'},
      {value: 'previous-month', label: 'Vorige maand'}
    ]
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.state === 'data-ready') {
      this.subjects = [...new Set(this.results.map(result => result.Subject))];
      this.setDataPoints();
    }
  }

  updateResults() {
    this.eventEmitter.emit();
  }

  setDataPoints(compareTo: string | null = null) {
    this.chartData = [];
    this.calculateDataPoints(this.resultsToday, 'vandaag');
    if (compareTo) {
      const compareToDate = calculateMinusDays(compareTo);
      const dates = MomentCalculateUtil(this.dataTimesToday.startDateTime, this.dataTimesToday.endDateTime, compareToDate);
      const result = getResults(this.results, dates.compareDateStart, dates.compareDateEnd);
      this.calculateDataPoints(result, LabelTranslationModel(compareTo));
    }
  }

  calculateDataPoints(result: Array<ResultsModel>, label: string) {
    this.chartData.push({label: label, data: []});
    this.subjects.forEach(subject => {
      let progress = result
        .filter(result => result.Subject === subject)
        .map(result => {
          return result.Progress
        })
        .reduce((sum, current) => sum + current, 0);
      const updateDatePoint = this.chartData.find(date => date.label === label);
      if (updateDatePoint) {
        updateDatePoint.data.push(progress);
      }
    })
    this.state = 'ready';
  }

}

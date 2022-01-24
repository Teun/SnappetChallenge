import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {ResultsModel} from "../../../models/results.model";
import {DateModel} from "../../../models/date.model";
import {ChartModel} from "../../../models/chart.model";
import {ButtonToggleModel} from "../../../models/button-toggle.model";
import {calculateMinusDays, MomentCalculateUtil} from "../../utils/moment-calculate.util";
import {getResults} from "../../utils/date.utils";
import {LabelTranslationModel} from "../../../models/label-translation.model";

@Component({
  selector: 'app-domain-results',
  templateUrl: './domain-results.component.html',
  styleUrls: ['./domain-results.component.scss']
})
export class DomainResultsComponent implements OnInit, OnChanges {

  @Input() state: string;
  @Input() results: Array<ResultsModel>;
  @Input() resultsToday: Array<ResultsModel>;
  @Input() dataTimesToday: DateModel;

  @Output() eventEmitter = new EventEmitter;

  resultsSubject: Array<ResultsModel>;

  chartData: Array<ChartModel>;

  subjects: Array<string>;

  buttonToggleValues: Array<ButtonToggleModel>;

  activeSubject: string;

  constructor() {
  }

  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.state === 'data-ready') {
      const buttonToggleSubjects = [...new Set(this.results.map(result => result.Subject))];
      this.buttonToggleValues = buttonToggleSubjects.map((subject, index) => {
        return {value: subject, label: subject, active: index === 0}
      });

      const subject = this.buttonToggleValues.find(item => item.active)!.value;

      this.setDataPoints(subject);
    }
  }

  updateResults() {
    this.eventEmitter.emit();
  }

  setDataPoints(subject: string) {
    this.activeSubject = subject;
    this.chartData = [];
    this.resultsSubject = this.resultsToday.filter(result => result.Subject === this.activeSubject);
    this.subjects = [...new Set(this.resultsSubject.map(result => result.Domain))];
    this.calculateDataPoints(this.resultsSubject, subject);
  }

  calculateDataPoints(result: Array<ResultsModel>, label: string) {
    this.chartData.push({label: label, data: []});
    this.subjects.forEach(subject => {
      let progress = result
        .filter(result => result.Domain === subject)
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

import {Component, OnDestroy, OnInit} from '@angular/core';
import {DataPointsModel} from "../../models/data-points.model";
import {ResultsModel} from "../../models/results.model";
import {ResultService} from "../../services/result.service";
import {FormControl, FormGroup} from "@angular/forms";
import {Subscription} from "rxjs";
import * as moment from "moment";
import {calculateMinusDays, MomentCalculateUtil} from "../utils/moment-calculate.util";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {

  compareToGroup: FormGroup;
  compareToControl = new FormControl(null);

  results: Array<ResultsModel>;
  resultsToday: Array<ResultsModel>;
  subjects: Array<string>;
  dataPoints: Array<DataPointsModel>;

  compareSubscription: Subscription;

  today = new Date('2015-03-24T00:00:00.000');
  now = new Date('2015-03-24T11:30:00.000');

  state = 'loading';

  constructor(private resultService: ResultService,
              private _snackBar: MatSnackBar) {
    this.compareToGroup = new FormGroup({
        compareToControl: this.compareToControl
      });
  }

  ngOnInit(): void {
    this.updateResults();

    this.compareSubscription = this.compareToControl.valueChanges.subscribe(value => {
      this.setDataPoints(value);
    })
  }

  updateResults() {
    this.state = 'loading';
    this.resultService.getResults().subscribe({
      next: (data: ResultsModel[]) => {
        this.results = data;
        this.subjects = [...new Set(this.results.map(result => result.Subject))];
        this.resultsToday = this.getResults(this.today, this.now);
        this.setDataPoints();
      }, error: () => {
        this.state = 'error';
        this.openSnackBar('We konden de resultaten niet ophalen!', 'X')
      }});
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }

  getResults(startDateTime: Date, endDateTime: Date): Array<ResultsModel> {
    return this.results.filter(result => (new Date(result.SubmitDateTime) >= startDateTime && (new Date(result.SubmitDateTime) < endDateTime)));
  }

  setDataPoints(compareTo: string | null = null) {
    this.dataPoints= [];
    this.calculateDataPoints(this.resultsToday, 'vandaag');
    if(compareTo) {
      const compareToDate = calculateMinusDays(compareTo);
      const dates = MomentCalculateUtil(this.today, this.now, compareToDate);
      const result = this.getResults(dates.compareDateStart, dates.compareDateEnd);
      this.calculateDataPoints(result, compareTo);
    }
  }

  calculateDataPoints(result: Array<ResultsModel>, label: string){
    this.dataPoints.push({label: label, data: []});
    this.subjects.forEach(subject => {
      let progress = result
        .filter(result => result.Subject === subject)
        .map(result => {return result.Progress })
        .reduce((sum, current) => sum + current, 0);
      const updateDatePoint = this.dataPoints.find(date => date.label === label);
      if(updateDatePoint) {
        updateDatePoint.data.push(progress);
      }
    })
    this.state = 'ready';
  }

  ngOnDestroy() {
    this.compareSubscription.unsubscribe();
  }

}

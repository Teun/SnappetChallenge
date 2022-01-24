import {Component, OnInit} from '@angular/core';
import {ResultsModel} from "../../models/results.model";
import {ResultService} from "../../services/result.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {getResults} from "../utils/date.utils";
import {DateModel} from "../../models/date.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  results: Array<ResultsModel>;
  resultsToday: Array<ResultsModel>;

  dateTimesToday: DateModel = {
    startDateTime: new Date('2015-03-24T00:00:00.000'),
    endDateTime: new Date('2015-03-24T11:30:00.000')
  };

  state = 'loading';

  constructor(private resultService: ResultService,
              private _snackBar: MatSnackBar) {

  }

  ngOnInit(): void {
    this.updateResults();
  }

  updateResults() {
    this.state = 'loading';
    this.resultService.getResults().subscribe({
      next: (data: ResultsModel[]) => {
        this.results = data;
        this.resultsToday = getResults(this.results, this.dateTimesToday.startDateTime, this.dateTimesToday.endDateTime);
        this.state = 'data-ready';
        }, error: () => {
        this.state = 'error';
        this.openSnackBar('We konden de resultaten niet ophalen!', 'X')
      }
    });
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }

}

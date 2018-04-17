import { Component, OnInit } from '@angular/core';
import * as fromRoot from 'app/store/reducers';
import * as fromReports from 'app/store/reducers/reports';
import { MdDialog } from '@angular/material';
import * as Action from 'app/store/actions/reports/report.action';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {
  IsBusy: number;
  jsonData: string;

  constructor(private store: Store<fromRoot.State>, public dialog: MdDialog) {
    this.store.select(_ => _.report.loading).subscribe(busy => this.IsBusy = busy);
  }

  ngOnInit() {
  }

  submitJson() {
      if(this.IsBusy === 0){
        this.store.dispatch(new Action.SendJsonAction(this.jsonData))
      }
  }

}

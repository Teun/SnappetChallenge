import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as actions from 'app/store/actions/signs/sign.action';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-resend-email',
  templateUrl: './resend-email.component.html',
  styleUrls: ['./resend-email.component.scss']
})
export class ResendEmailComponent implements OnInit {
  username: string;
  sent: Observable<boolean>;
  IsBusy: Observable<boolean>;

  constructor(private store: Store<fromRoot.State>, private route: ActivatedRoute) {
    this.IsBusy = store.select(r => r.sign.busy);
    this.sent = store.select(r => r.sign.emailResent);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.username = params['username'];
    });
  }

  resendEmail() {
    this.store.dispatch(new actions.ResendEmailAction(this.username));
  }

}

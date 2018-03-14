import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as actions from 'app/store/actions/signs/sign.action';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  model: any = {} // as Nicollas.Dto.Identity.userDto;
  password_confirmation: string;
  phoneMask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
  domains: Observable<string[]>;
  emailDomain: string;
  IsBusy: Observable<boolean>;
  error: Observable<any>

  constructor(private router: Router, private store: Store<fromRoot.State>) {
    this.IsBusy = store.select(r => r.sign).map(state => state.busy);
    this.domains = store.select(r => r.sign).map(state => state.domains);
    // this.domains.distinctUntilChanged().subscribe(data => console.log(data));
    this.error = store.select(r => r.sign).map(state => JSON.parse(state.error));
    const sub = store.select(r => r.sign).map(state => state.signupRequested).distinctUntilChanged().subscribe(result => {
      if (result) {
        this.router.navigate(['ResendConfirmation', this.model.userName]);
        sub.unsubscribe();
      }
    });
  }

  ngOnInit() {
    this.store.dispatch(new actions.DomainAction());
  }

  signup() {
    if (this.model.password !== this.password_confirmation) {
      return;
    }
    const clone = Object.assign({}, this.model, { email: this.model.email + this.emailDomain });
    this.store.dispatch(new actions.SignupAction(clone));
  }
}

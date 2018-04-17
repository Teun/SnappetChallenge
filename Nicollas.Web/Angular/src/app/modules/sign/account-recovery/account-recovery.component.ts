import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as actions from 'app/store/actions/signs/sign.action';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-account-recovery',
  templateUrl: './account-recovery.component.html',
  styleUrls: ['./account-recovery.component.scss']
})
export class AccountRecoveryComponent implements OnInit {
  model = {} as Nicollas.Dto.Identity.userDto;
  userId: string;
  token: string;
  password: string; password_confirmation: string;
  resetPassword = false;
  IsBusy: Observable<boolean>;
  erro: Observable<string>;
  result = false;

  constructor(private store: Store<fromRoot.State>, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.IsBusy = this.store.select(r => r.sign.busy);
    this.erro = this.store.select(r => r.sign.error);
    this.route.params.subscribe(params => {
      this.userId = <string>params['userId'];
      this.token = params['token'];
      if (this.token && this.userId) {
        this.resetPassword = true;
      }
    });
  }

  sendToken() {
    if (this.password !== this.password_confirmation) {
      return;
    }
    this.store.select(r => r.sign.tokenActived).distinctUntilChanged().take(1).subscribe(result => {
      if (result) {
        this.router.navigate(['/login']);
      }
    });
    this.store.dispatch(new actions.TokenAction({id: this.userId, token: this.token, password: this.password}));
  }

  recovery() {
    this.IsBusy.distinctUntilChanged().skip(2).take(1).subscribe(_ => this.result = true);
    this.store.dispatch(new actions.AccountRecoveryAction(Object.assign({}, this.model)));
  }
}

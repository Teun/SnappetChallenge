import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as actions from 'app/store/actions/signs/sign.action';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-new-password',
  templateUrl: './new-password.component.html',
  styleUrls: ['./new-password.component.scss']
})
export class NewPasswordComponent implements OnInit, OnDestroy {

  IsBusy: Observable<boolean>;
  erro: Observable<string>;
  userName: string;
  userId: string;
  model = { password: '', confirm: '' }
  private subscriptions: Subscription[] = [];

  constructor(private store: Store<fromRoot.State>, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.IsBusy = this.store.select(r => r.sign.busy);
    this.erro = this.store.select(r => r.sign.error);
    this.route.params.subscribe(params => {
      this.userName = <string>params['username'];
      this.userId = <string>params['userId'];
    });
    this.subscriptions.push(this.store.select(_ => _.sign.lastActionOnReducer).distinctUntilChanged().subscribe(data => {
      switch (data) {
        case actions.DEFAULT_PASSWORD_COMPLETE:
          this.store.dispatch(
            new actions.LogInRequestAction(
              {userName: this.userName, password: this.model.password} as Nicollas.Dto.Identity.userDto));
          break;
        case actions.LOG_IN_COMPLETE: {
          this.router.navigate(['']);
        }
      }
    }));
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  submit() {
    this.store.dispatch(new actions.DefaultPasswordAction({ id: this.userId, password: this.model.password }));
  }
}

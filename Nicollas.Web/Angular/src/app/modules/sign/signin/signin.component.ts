import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as actions from 'app/store/actions/signs/sign.action';
import { Subscription } from 'rxjs/Subscription';

@Component({
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.scss']
})

export class SigninComponent implements OnInit {
    model = { userName: '', password: '' } as Nicollas.Dto.Identity.userDto; // = {username: 'batman', password: 'KillSuperman!'};
    loading: Observable<boolean>;
    returnUrl: string;
    statusError: Observable<string>;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private store: Store<fromRoot.State>) { }

    ngOnInit() {
        this.loading = this.store.select(s => s.sign.busy);
        this.statusError = this.store.select(s => s.sign.error).map(error => error ? error.text() : null);
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.params['returnUrl'] || '';

        const sub1 = this.store.select(s => s.sign.error)
            .distinctUntilChanged()
            .subscribe(error => {
                if (error && error.status === 401) {
                    this.router.navigate(['ResendConfirmation', this.model.userName]);
                    if (sub1) {
                        sub1.unsubscribe();
                    }
                }
                if (error && error.status === 406) {
                    this.router.navigate(['NewPassword', this.model.userName, error.text()]);
                    if (sub1) {
                        sub1.unsubscribe();
                    }
                }
            });
        const sub2 = this.store.select(s => s.sign.authenticated)
            .distinctUntilChanged()
            .subscribe(data => {
                if (data) {
                    this.router.navigate([this.returnUrl]);
                    if (sub2) {
                        sub2.unsubscribe();
                    }
                }
            });
    }

    signIn() {
        this.store.dispatch(new actions.LogInRequestAction(Object.assign({}, this.model)));
    }
}

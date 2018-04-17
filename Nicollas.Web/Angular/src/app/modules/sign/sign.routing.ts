import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { ResendEmailComponent } from './resend-email/resend-email.component';
import { AccountRecoveryComponent } from './account-recovery/account-recovery.component';
import { NewPasswordComponent } from 'app/modules/sign/new-password/new-password.component';

const routes: Routes = [
  // { path: '', redirectTo: 'Login', pathMatch: 'full'},
  { path: 'login', component: SigninComponent },
  { path: 'signup', component: SignupComponent, data: { 'claims': ['NOT_ALLOW'] } },
  { path: 'AccountConfirmed', component: ConfirmationComponent, data: { 'claims': ['NOT_ALLOW'] } },
  { path: 'AccountRecovery', component: AccountRecoveryComponent, data: { 'claims': ['NOT_ALLOW'] } },
  { path: 'AccountRecovery/:token/:userId', component: AccountRecoveryComponent, data: { 'claims': ['NOT_ALLOW'] } },
  { path: 'NewPassword/:username/:userId', component: NewPasswordComponent, data: { 'claims': ['NOT_ALLOW'] } },
  { path: 'ResendConfirmation/:username', component: ResendEmailComponent, data: { 'claims': ['NOT_ALLOW'] } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SignRoutingModule { }

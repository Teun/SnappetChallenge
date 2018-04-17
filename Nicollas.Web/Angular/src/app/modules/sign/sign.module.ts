import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextMaskModule } from 'angular2-text-mask';
import { MaterialModule } from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { SharedModule } from '../shared/shared.module';

import { SignRoutingModule } from './sign.routing';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent} from './signup/signup.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { ResendEmailComponent } from './resend-email/resend-email.component';
import { AccountRecoveryComponent } from './account-recovery/account-recovery.component';
import { EffectsModule } from '@ngrx/effects';
import { SignEffects } from 'app/store/effects/signs/sign.effect';
import { SignService } from 'app/services/signs/sign.service';
import { NewPasswordComponent } from './new-password/new-password.component';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    BrowserAnimationsModule,
    SignRoutingModule,
    TextMaskModule,
    MaterialModule,


    EffectsModule.forFeature([SignEffects]),
  ],
  providers: [
    SignService
  ],
  declarations: [
    SigninComponent,
    SignupComponent,
    ConfirmationComponent,
    ResendEmailComponent,
    AccountRecoveryComponent,
    NewPasswordComponent
  ]
})
export class SignModule { }

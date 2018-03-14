import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MdTableModule } from '@angular/material';
import { CdkTableModule } from '@angular/cdk';

import { SharedModule } from '../shared/shared.module';

import { TextMaskModule } from 'angular2-text-mask';

import { AdminRoutingModule } from './admin.routing';

import { BsModalModule } from 'Ng2-bs3-modal';
import { EffectsModule } from '@ngrx/effects';


import { FileUploadModule } from 'ng2-file-upload';
import { UsersComponent } from './users/users.component';
import { UserEffects } from 'app/store/effects/identity/user.effect';
import { RoleEffects } from 'app/store/effects/identity/role.effect';
import { UserService } from 'app/services/identity/user.service';
import { RoleService } from 'app/services/identity/role.service';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CdkTableModule,
    MdTableModule,
    AdminRoutingModule,
    BsModalModule,
    TextMaskModule,

    FileUploadModule,
    EffectsModule.forFeature([
      UserEffects,
      RoleEffects
    ]),
  ],
  providers: [
    UserService,
    RoleService,
  ],
  declarations: [
    UsersComponent,
  ]
})
export class AdminModule { }

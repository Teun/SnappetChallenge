import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '@angular/material';

// Sidenav
import { AppSidenavComponent } from './layout/sidenav/sidenav.component';
// Header
import { AppHeaderComponent } from './layout/header/header.component';
// Footer

// BASE COMPONENT
import { BaseComponent } from './layout/base.component';
import { DialogComponent } from 'app/utils/dialog/dialog.component';

@NgModule({
  imports:      [
      CommonModule,
      RouterModule,
      MaterialModule,
      FormsModule,
  ],
  declarations: [
      AppSidenavComponent,
      AppHeaderComponent,
      BaseComponent,
      DialogComponent,
  ],
  entryComponents: [DialogComponent],
  exports:      [
      AppSidenavComponent,
      AppHeaderComponent,
      BaseComponent,
      DialogComponent,
      CommonModule, FormsModule, MaterialModule
    ]
})
export class SharedModule { }


/*
Copyright 2017 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/

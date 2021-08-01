import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatRadioModule } from '@angular/material/radio';

import { UsersPageComponent } from './users-page.component';
import { ComponentsModule } from '../../components/components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    MatRadioModule,

    ComponentsModule
  ],
  declarations: [
    UsersPageComponent
  ],
  exports: [
    UsersPageComponent
  ]
})
export class UsersPageModule { }

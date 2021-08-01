import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatRadioModule } from '@angular/material/radio';
import { MatDividerModule } from '@angular/material/divider';

import { UsersPageComponent } from './users-page.component';
import { ComponentsModule } from '../../components/components.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    MatRadioModule,
    MatDividerModule,

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

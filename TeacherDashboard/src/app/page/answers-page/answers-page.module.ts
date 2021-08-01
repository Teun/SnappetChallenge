import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnswersPageComponent } from './answers-page.component';
import { ComponentsModule } from '../../components/components.module';



@NgModule({
  imports: [
    CommonModule,

    ComponentsModule
  ],
  declarations: [
    AnswersPageComponent
  ],
  exports: [
    AnswersPageComponent
  ]
})
export class AnswersPageModule { }

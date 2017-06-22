import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule } from "@angular/http";
import { NgModule } from '@angular/core';
import { MaterialModule } from "@angular/material";

import { AppComponent } from './app.component';
import { WorkResultService } from './services/work-result.service';
import { UserComponentComponent } from './components/user-component/user-component.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponentComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [
    WorkResultService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

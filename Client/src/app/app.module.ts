import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DailyInsightsComponent } from './daily-insights/daily-insights.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDatepickerModule,MatInputModule,MatButtonModule,MatNativeDateModule,MatTableModule,MatPaginatorModule} from "@angular/material";
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './navbar/navbar.component'; 
@NgModule({
  declarations: [
    AppComponent,
    DailyInsightsComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatInputModule,
    MatButtonModule,
    MatNativeDateModule,
    MatTableModule,
    MatPaginatorModule  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

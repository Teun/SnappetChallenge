import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { StudentOverviewComponent } from './components/student-overview/student-overview.component';
import { ExerciseOverviewComponent } from './components/exercise-overview/exercise-overview.component';
import { FilteringFormComponent } from './components/filtering-form/filtering-form.component';
import { ExerciseListComponent } from './components/exercise-list/exercise-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    StudentOverviewComponent,
    ExerciseOverviewComponent,
    FilteringFormComponent,
    ExerciseListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

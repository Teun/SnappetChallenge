import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { appRouter } from './app.routing';
import { RouterModule } from '@angular/router';
import { MainPageComponent } from './pages/sc-main-page.component';
import { NavComponent } from './components/sc-nav.component';
import { ReportComponent } from './components/sc-report.component';
import { TableComponent } from './components/sc-table.component';
import { TableItemComponent } from './components/sc-table-item.components';
import { FilterComponent } from './components/sc-filter.component';
import { StudentService } from './services/student.service';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    RouterModule.forRoot(appRouter, { useHash: true }),
  ],
  declarations: [
    AppComponent,
    MainPageComponent,
    NavComponent,
    ReportComponent,
    TableComponent,
    TableItemComponent,
    FilterComponent
  ],
  providers: [
    StudentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

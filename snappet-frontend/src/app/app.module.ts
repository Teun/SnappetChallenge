import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TopbarComponent } from './components/topbar/topbar.component';
import {MatIconModule} from '@angular/material/icon';
import {RouterModule} from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import {AppRoutingModule} from './app-routing.module';
import {MatListModule} from '@angular/material/list';
import {MatButtonModule} from '@angular/material/button';
import {OverlayModule} from '@angular/cdk/overlay';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatCardModule} from '@angular/material/card';
import {HttpClientModule} from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule, MatOptionModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {CovalentLayoutModule} from '@covalent/core/layout';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {CovalentDynamicFormsModule} from '@covalent/dynamic-forms';
import {CovalentBaseEchartsModule} from '@covalent/echarts/base';
import {CovalentMarkdownModule} from '@covalent/markdown';
import {CovalentHighlightModule} from '@covalent/highlight';
import {CovalentHttpModule} from '@covalent/http';
import {CovalentStepsModule} from '@covalent/core/steps';
import { ProgressComponent } from './components/progress/progress.component';
import {CovalentToolboxEchartsModule} from '@covalent/echarts/toolbox';
import {CovalentPieEchartsModule} from '@covalent/echarts/pie';
import {CovalentTooltipEchartsModule} from '@covalent/echarts/tooltip';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {CovalentDataTableModule} from '@covalent/core/data-table';
import {MatRadioButton, MatRadioModule} from '@angular/material/radio';
import { ExerciseComponent } from './components/exercise/exercise.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatPaginatorModule} from '@angular/material/paginator';

@NgModule({
  declarations: [
    AppComponent,
    TopbarComponent,
    DashboardComponent,
    ProgressComponent,
    ExerciseComponent
  ],
  imports: [
    BrowserModule,
    MatIconModule,
    RouterModule,
    AppRoutingModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    OverlayModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatCardModule,
    MatGridListModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatSnackBarModule,
    CovalentLayoutModule,
    CovalentStepsModule,
    // (optional) Additional Covalent Modules imports
    CovalentHttpModule.forRoot(),
    CovalentHighlightModule,
    CovalentMarkdownModule,
    CovalentDynamicFormsModule,
    CovalentBaseEchartsModule,
    CovalentPieEchartsModule,
    CovalentToolboxEchartsModule,
    CovalentTooltipEchartsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    CovalentDataTableModule,
    MatRadioModule,
    MatExpansionModule,
    MatPaginatorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

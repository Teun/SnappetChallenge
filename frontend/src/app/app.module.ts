import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WorksService } from './_services/works.service';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from './shared/material.module';
import { UserActivityComponent } from './user-activity/user-activity.component';
import { ChartsModule } from 'ng2-charts';
import { LoadingService } from './_services/loading.service';
import { RouterModule } from '@angular/router';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { UserProgressComponent } from './user-progress/user-progress.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { DatePipe } from '@angular/common';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        UserActivityComponent,
        SidebarComponent,
        UserProgressComponent,
        ExercisesComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        RouterModule,

        MaterialModule,
        ChartsModule,
    ],
    providers: [
        WorksService,
        LoadingService,
        DatePipe,
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}

import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { HttpModule  } from '@angular/http';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { LearningObjectivePage} from '../pages/learning-objective/learning-objective';
import { StudentsPage } from '../pages/students/students';
import { StudentDetailPage } from '../pages/student-detail/student-detail';

import { DateSelectorComponent } from '../components/date-selector/date-selector';

import { DataService } from '../services/dataService';
import { CurrentDateService } from '../services/currentDateService';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    LearningObjectivePage,
    StudentsPage,
    StudentDetailPage,
    DateSelectorComponent
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    HttpModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    LearningObjectivePage,
    StudentsPage,
    StudentDetailPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    DataService,
    CurrentDateService
  ]
})
export class AppModule {}

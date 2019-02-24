import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { APP_INITIALIZER } from '@angular/core';
import { AppConfig } from './app-config';
import { LearningResultComponent } from './learning-result/learning-result.component';
import { LearningResultDetailComponent } from './learning-result-detail/learning-result-detail.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { SnappetDataService } from './services/snappet-data.service';

export function initializeApp(appConfig: AppConfig) {
    return () => appConfig.load();
}

@NgModule({
  declarations: [
    AppComponent,
    LearningResultComponent,
    LearningResultDetailComponent,
    NavComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule,
      NgbModule
  ],
    providers: [
        SnappetDataService,
        AppConfig,
        {
            provide: APP_INITIALIZER,
            useFactory: initializeApp,
            deps: [AppConfig], multi: true
        }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

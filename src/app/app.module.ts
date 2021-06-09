import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSelectModule} from "@angular/material/select";
import {MatInputModule} from "@angular/material/input";
import {FormsModule} from "@angular/forms";
import {MatTableModule} from '@angular/material/table';
import {MatSortModule} from "@angular/material/sort";
import {MatTabsModule} from "@angular/material/tabs";
import {RouterModule} from "@angular/router";
import {AnswersComponent} from "./components/answers/answers.component";
import {StatisticsComponent} from "./components/statistics/statistics.component";
import {AppRoutingModule} from "./app-routing.module";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {SocketIoConfig, SocketIoModule} from "ngx-socket-io";
import {AnswersContainer} from "./containers/answers.container";
import {LearningObjectiveComponent} from "./components/learning-objective/learning-objective.component";
import {AnswerEmoticonsComponent} from "./components/answer-emoticons/answer-emoticons.component";
import {PerformanceIndicatorComponent} from "./components/performance-indicator/performance-indicator.component";
import {ControlsComponent} from "./components/controls/controls.component";
import {StatisticsContainer} from "./containers/statistics.container";
import {ServerUnavailableComponent} from "./components/server-unavailable/server-unavailable.component";
import {ActionReducer, MetaReducer, StoreModule} from "@ngrx/store";
import {answersReducer} from "./ngrx/answers.reducer";
import {EffectsModule} from "@ngrx/effects";
import {AnswersEffects} from "./ngrx/answers.effects";
import {localStorageSync} from "ngrx-store-localstorage";

const socketConfig: SocketIoConfig = { url: 'http://localhost:8988', options: {} };

export function localStorageSyncReducer(reducer: ActionReducer<any>): ActionReducer<any> {
  return localStorageSync({ keys: ['answers'], rehydrate: true })(reducer);
}
const metaReducers: Array<MetaReducer<any, any>> = [localStorageSyncReducer];

@NgModule({
  declarations: [
    AppComponent,
    AnswersComponent,
    AnswersContainer,
    StatisticsComponent,
    LearningObjectiveComponent,
    AnswerEmoticonsComponent,
    PerformanceIndicatorComponent,
    ControlsComponent,
    StatisticsContainer,
    ServerUnavailableComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
    MatTableModule,
    MatSortModule,
    MatTabsModule,
    RouterModule,
    AppRoutingModule,
    MatIconModule,
    MatButtonModule,
    SocketIoModule.forRoot(socketConfig),
    StoreModule.forRoot({ answers: answersReducer }, { metaReducers }),
    EffectsModule.forRoot([AnswersEffects]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

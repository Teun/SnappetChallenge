import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ChartsModule } from 'ng2-charts';
import { SharedModule } from 'src/app/shared/shared.module';
import { MyClassPageLayoutComponent } from './my-class-page-layout/my-class-page-layout.component';
import { MyClassRoutingModule } from './my-class-routing.module';
import { OverviewEffects } from './store/overview.effects';
import * as fromClassOverview from './store/overview.reducer';
import { OverviewResolver } from './store/overview.resolver';


@NgModule({
  declarations: [
    MyClassPageLayoutComponent
  ],
  imports: [
    CommonModule,
    MyClassRoutingModule,
    SharedModule,
    ChartsModule,
    StoreModule.forFeature(fromClassOverview.OverviewFeatureKey, fromClassOverview.OverviewReducer),
    EffectsModule.forFeature([OverviewEffects])
  ],
  providers: [OverviewResolver]
})
export class MyClassModule { }

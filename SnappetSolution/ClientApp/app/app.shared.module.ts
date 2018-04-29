import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { ReportComponent } from './components/report/report.component';
import { WorkResultService } from './services/work-results.service';

@NgModule({
    declarations: [
        AppComponent,     
        ReportComponent,       
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule     
    ],
    providers: [WorkResultService]
})
export class AppModuleShared {
}

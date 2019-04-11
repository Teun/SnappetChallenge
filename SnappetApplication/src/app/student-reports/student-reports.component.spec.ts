import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentReportsComponent } from './student-reports.component';
import { ChartsModule } from 'ng2-charts';
import { AgGridModule } from 'ag-grid-angular';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { StudentDetailsServices } from '../student-details/student-details.services';
import { ResultsServices } from '../services/results.services';
import { StudentsServices } from '../services/students.services';
import { StudentReportServices } from './student-reports.services';
import { StudentSummaryServices } from '../student-summary/student-summary.service';
import { ImagePreloadDirective } from '../image-preload/image-preload.directive';
import { StudentReportCardComponent } from '../student-report-card/student-report-card.component';

describe('StudentReportsComponent', () => {
  let component: StudentReportsComponent;
  let fixture: ComponentFixture<StudentReportsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentReportsComponent, StudentReportCardComponent, ImagePreloadDirective ],
      imports: [ChartsModule, HttpClientTestingModule, RouterTestingModule],
      providers: [StudentReportServices, StudentSummaryServices, ResultsServices, StudentsServices]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

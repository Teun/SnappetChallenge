import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentSummaryComponent } from './student-summary.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { StudentSummaryServices } from './student-summary.service';
import { ResultsServices } from '../services/results.services';
import { StudentsServices } from '../services/students.services';
import { ChartsModule } from 'ng2-charts';

describe('StudentSummaryComponent', () => {
  let component: StudentSummaryComponent;
  let fixture: ComponentFixture<StudentSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [StudentSummaryComponent],
      imports: [ChartsModule, HttpClientTestingModule, RouterTestingModule],
      providers: [StudentSummaryServices, ResultsServices, StudentsServices]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentReportCardComponent } from './student-report-card.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('StudentReportCardComponent', () => {
  let component: StudentReportCardComponent;
  let fixture: ComponentFixture<StudentReportCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [StudentReportCardComponent],
      imports: [RouterTestingModule]

    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentReportCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

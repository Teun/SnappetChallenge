import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentSummaryComponent as StudentSummary } from './student-summary.component';

describe('StudentSummary', () => {
  let component: StudentSummary;
  let fixture: ComponentFixture<StudentSummary>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentSummary ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentSummary);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

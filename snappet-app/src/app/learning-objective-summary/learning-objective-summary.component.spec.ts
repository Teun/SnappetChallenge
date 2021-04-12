import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningObjectiveSummaryComponent } from './learning-objective-summary.component';

describe('LearningObjectiveSummaryComponent', () => {
  let component: LearningObjectiveSummaryComponent;
  let fixture: ComponentFixture<LearningObjectiveSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningObjectiveSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningObjectiveSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

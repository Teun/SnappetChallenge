import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningResultDetailComponent } from './learning-result-detail.component';

describe('LearningResultDetailComponent', () => {
  let component: LearningResultDetailComponent;
  let fixture: ComponentFixture<LearningResultDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LearningResultDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningResultDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

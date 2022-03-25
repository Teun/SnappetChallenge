import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualLevelEstimationComponent } from './actual-level-estimation.component';

describe('ActualLevelEstimationComponent', () => {
  let component: ActualLevelEstimationComponent;
  let fixture: ComponentFixture<ActualLevelEstimationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ActualLevelEstimationComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualLevelEstimationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

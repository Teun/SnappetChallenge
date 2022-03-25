import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelativeProgressComponent } from './relative-progress.component';

describe('RelativeProgressComponent', () => {
  let component: RelativeProgressComponent;
  let fixture: ComponentFixture<RelativeProgressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RelativeProgressComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RelativeProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

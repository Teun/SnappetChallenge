import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyInsightsComponent } from './daily-insights.component';

describe('DailyInsightsComponent', () => {
  let component: DailyInsightsComponent;
  let fixture: ComponentFixture<DailyInsightsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailyInsightsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyInsightsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

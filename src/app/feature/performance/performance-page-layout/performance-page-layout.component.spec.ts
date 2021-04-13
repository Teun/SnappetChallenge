import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerformancePageLayoutComponent } from './performance-page-layout.component';

describe('PerformancePageLayoutComponent', () => {
  let component: PerformancePageLayoutComponent;
  let fixture: ComponentFixture<PerformancePageLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PerformancePageLayoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PerformancePageLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

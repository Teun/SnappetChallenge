import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassChartsComponent } from './class-charts.component';

describe('ClassChartsComponent', () => {
  let component: ClassChartsComponent;
  let fixture: ComponentFixture<ClassChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassChartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

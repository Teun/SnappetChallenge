import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducatorTeachingOverviewComponent } from './educator-teaching-overview.component';

describe('EducatorTeachingOverviewComponent', () => {
  let component: EducatorTeachingOverviewComponent;
  let fixture: ComponentFixture<EducatorTeachingOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EducatorTeachingOverviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EducatorTeachingOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

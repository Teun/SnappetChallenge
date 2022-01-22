import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassResultsComponent } from './class-results.component';

describe('ClassResultsComponent', () => {
  let component: ClassResultsComponent;
  let fixture: ComponentFixture<ClassResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

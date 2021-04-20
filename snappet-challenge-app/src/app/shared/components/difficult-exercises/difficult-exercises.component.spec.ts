import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DifficultExercisesComponent } from './difficult-exercises.component';

describe('DifficultExercisesComponent', () => {
  let component: DifficultExercisesComponent;
  let fixture: ComponentFixture<DifficultExercisesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DifficultExercisesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DifficultExercisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

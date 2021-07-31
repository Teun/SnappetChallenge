import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListExcercisesComponent } from './list-excercises.component';

describe('ListExcercisesComponent', () => {
  let component: ListExcercisesComponent;
  let fixture: ComponentFixture<ListExcercisesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListExcercisesComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListExcercisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

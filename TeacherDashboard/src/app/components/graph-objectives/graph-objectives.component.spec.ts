import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphObjectivesComponent } from './graph-objectives.component';

describe('GraphObjectivesComponent', () => {
  let component: GraphObjectivesComponent;
  let fixture: ComponentFixture<GraphObjectivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraphObjectivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GraphObjectivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

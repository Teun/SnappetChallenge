import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphSubjectGroupsComponent } from './graph-subject-groups.component';

describe('GraphSubjectGroupsComponent', () => {
  let component: GraphSubjectGroupsComponent;
  let fixture: ComponentFixture<GraphSubjectGroupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraphSubjectGroupsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GraphSubjectGroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSubjectGroupsComponent } from './list-subject-groups.component';

describe('ListSubjectGroupsComponent', () => {
  let component: ListSubjectGroupsComponent;
  let fixture: ComponentFixture<ListSubjectGroupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListSubjectGroupsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListSubjectGroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

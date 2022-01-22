import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DomainResultsComponent } from './domain-results.component';

describe('DomainResultsComponent', () => {
  let component: DomainResultsComponent;
  let fixture: ComponentFixture<DomainResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DomainResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DomainResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

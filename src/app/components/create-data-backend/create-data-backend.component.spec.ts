import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDataBackendComponent } from './create-data-backend.component';

describe('CreateDataBackendComponent', () => {
  let component: CreateDataBackendComponent;
  let fixture: ComponentFixture<CreateDataBackendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDataBackendComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDataBackendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

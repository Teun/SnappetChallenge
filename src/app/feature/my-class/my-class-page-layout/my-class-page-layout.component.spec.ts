import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { Observable } from 'rxjs';
import { PlotGraphService } from 'src/app/core/services/plotgraph/plot-graph.service';
import { AppState } from 'src/app/store/reducer';

import { MyClassPageLayoutComponent } from './my-class-page-layout.component';

describe('MyClassPageLayoutComponent', () => {
  let component: MyClassPageLayoutComponent;
  let fixture: ComponentFixture<MyClassPageLayoutComponent>;
  let actions: Observable<any>;
  const plotGraphService = jasmine.createSpyObj('PlotGraphService', ['plotChartData']);
  plotGraphService.plotChartData.and.returnValue({
    objective: {}
  });
  const initialState = {
      products : {
    ids: [
      '1'
    ],
    entities: {
      1: {
        SubmittedAnswerId: 39176933,
        SubmitDateTime: '2015-03-13T08:42:28.450',
        Correct: 1,
        Progress: 0,
        UserId: 40283,
        ExerciseId: 430410,
        Difficulty: 'NULL',
        Subject: 'Rekenen',
        Domain: 'Getallen',
        LearningObjective: 'Optellen en aftrekken > 1000 met strategieen'
    }
    }}
  };
  let store: MockStore<AppState>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyClassPageLayoutComponent ],
      providers: [
        provideMockStore({initialState}),
        { provide: PlotGraphService, useValue: plotGraphService },
        provideMockActions(() => actions),
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
    .compileComponents();
    store = TestBed.inject(MockStore);
  });

  beforeEach( () => {
     fixture = TestBed.createComponent(MyClassPageLayoutComponent);
     component = fixture.componentInstance;
     fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Observable } from 'rxjs';
import { AppState } from 'src/app/store/reducer';
import { TestScheduler } from 'rxjs/testing';
import { ClassOverviewService } from '../../../../core/services/class-overview/class-overview.service';
import { OverviewEffects } from '../overview.effects';
import { OverviewAction } from '../overview.actiontype';
import { RouterTestingModule } from '@angular/router/testing';

describe('Overview Effects tests suit', () => {
    const initialState = {
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
        }
      };
    let effects: OverviewEffects;
    let store: MockStore<AppState>;
    let actions: Observable<any>;
    const OverviewHttpService = jasmine.createSpyObj('ClassOverviewService', [
        'fetchResults'
      ]);
    let testScheduler;

    beforeEach(() => {

        TestBed.configureTestingModule({
          imports: [
            RouterTestingModule,
          ],
            providers : [
                OverviewEffects,
                provideMockStore({initialState}),
                provideMockActions(() => actions),
                { provide: ClassOverviewService, useValue: OverviewHttpService }
            ]
        });

        effects = TestBed.inject(OverviewEffects);
        store = TestBed.inject(MockStore);
        store.setState({ Overviews: {}});

        testScheduler = new TestScheduler((actual, expected) => {
            expect(actual).toEqual(expected);
          });

    });

    it('should handle OverviewActions.Overviews fetched event', () => {
        const payload = { };
        const action = OverviewAction.overviewFetched;
        testScheduler.run(({ hot, cold, expectObservable }) => {
          });
    });
});


import { TestBed } from '@angular/core/testing';

import { WorkResultsServiceService } from './work-results-service.service';

describe('WorkResultsServiceService', () => {
  let service: WorkResultsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkResultsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

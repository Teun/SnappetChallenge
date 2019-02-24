import { TestBed } from '@angular/core/testing';

import { SnappetDataService } from './snappet-data.service';

describe('SnappetDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SnappetDataService = TestBed.get(SnappetDataService);
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { AppContextService } from './appcontext.service';

describe('AppcontextService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppContextService = TestBed.get(AppContextService);
    expect(service).toBeTruthy();
  });
});

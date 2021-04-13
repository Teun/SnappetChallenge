import { TestBed } from '@angular/core/testing';

import { PlotGraphService } from './plot-graph.service';

describe('PlotGraphService', () => {
  let service: PlotGraphService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlotGraphService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

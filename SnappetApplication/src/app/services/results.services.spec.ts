import { TestBed } from '@angular/core/testing';

import { ResultsServices } from './results.services';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { StudentsServices } from './students.services';

describe('ResultsServices', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [ResultsServices, StudentsServices]
  }));

  it('should be created', () => {
    const service: ResultsServices = TestBed.get(ResultsServices);
    expect(service).toBeTruthy();
  });
});

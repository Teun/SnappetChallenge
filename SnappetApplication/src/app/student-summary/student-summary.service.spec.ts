import { TestBed } from '@angular/core/testing';

import { StudentSummaryServices } from './student-summary.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ResultsServices } from '../services/results.services';
import { StudentsServices } from '../services/students.services';

describe('StudentSummaryServices', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [StudentSummaryServices, ResultsServices, StudentsServices]
  }));

  it('should be created', () => {
    const service: StudentSummaryServices = TestBed.get(StudentSummaryServices);
    expect(service).toBeTruthy();
  });
});

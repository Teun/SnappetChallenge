import { TestBed } from '@angular/core/testing';

import { StudentReportServices } from './student-reports.services';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { StudentSummaryServices } from '../student-summary/student-summary.service';
import { ResultsServices } from '../services/results.services';
import { StudentsServices } from '../services/students.services';

describe('StudentReportServices', () => {

  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [StudentReportServices, StudentSummaryServices, ResultsServices, StudentsServices]
  }));

  it('should be created', () => {
    const service: StudentReportServices = TestBed.get(StudentReportServices);
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { StudentDetailsServices } from './student-details.services';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ResultsServices } from '../services/results.services';
import { StudentsServices } from '../services/students.services';

describe('StudentDetailsServices', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [StudentDetailsServices, ResultsServices, StudentsServices]
  }));

  it('should be created', () => {
    const service: StudentDetailsServices = TestBed.get(StudentDetailsServices);
    expect(service).toBeTruthy();
  });
});

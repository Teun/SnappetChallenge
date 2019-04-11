import { TestBed } from '@angular/core/testing';

import { StudentsServices } from './students.services';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('StudentsServices', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [StudentsServices]
  }));

  it('should be created', () => {
    const service: StudentsServices = TestBed.get(StudentsServices);
    expect(service).toBeTruthy();
  });
});

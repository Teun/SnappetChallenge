import { TestBed } from '@angular/core/testing';

import { ClassOverviewService } from './class-overview.service';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';

describe('ClassOverviewService', () => {
  let service: ClassOverviewService;
  let  httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
          imports: [HttpClientTestingModule],
         providers: [ClassOverviewService] });
    service = TestBed.get(ClassOverviewService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it('should fetch data with an Observable<Overview[]>', () => {
          service.fetchResults().subscribe(data => {
              expect(data[0].UserId).toEqual(40283);
          });
          const request =  httpMock.expectOne('http://localhost:3000/rawData');
          httpMock.verify();
  });
});

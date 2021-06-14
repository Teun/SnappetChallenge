import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { DataService } from './data.service';
import { mock } from '../test-mock/work-test';

describe('DataService', () => {
  let service: DataService;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        HttpTestingController
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  // afterEach(() => {
  //   httpTestingController.verify();
  // });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  xit('should give correct "getWork" method', () => {
    service.getWork('', '', '', '').subscribe((result) => {
      expect(result).toEqual(mock.work);
      expect(result.length).toBe(mock.work.length);
    })
    let req = httpTestingController.expectOne(`http://localhost:3000/work`);    
    expect(req.request.method).toEqual('GET');
    req.flush(mock.work);    
  });

});

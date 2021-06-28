import {TestBed} from '@angular/core/testing';

import {ReportService} from './report.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {IStudentData} from "../models/IStudentData";

describe('ReportService', () => {
  let httpTestingController: HttpTestingController;
  let reportService: ReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    httpTestingController = TestBed.inject(HttpTestingController);
    reportService = TestBed.inject(ReportService);
  });

  afterEach(() => {
    httpTestingController.verify(); //Verifies that no requests are outstanding.
  });

  it('should create', () => {
    expect(reportService).toBeTruthy();
  });

  it('should return expected students data list (HttpClient called once)', (done: DoneFn) => {
    const expectedData: IStudentData[] = [
      {
        "SubmittedAnswerId": 2395278,
        "SubmitDateTime": "2015-03-02T07:35:38.740",
        "Correct": 1,
        "Progress": 0,
        "UserId": 40281,
        "ExerciseId": 1038396,
        "Difficulty": "-200",
        "Subject": "Begrijpend Lezen",
        "Domain": "-",
        "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
      },
      {
        "SubmittedAnswerId": 2396494,
        "SubmitDateTime": "2015-03-02T07:36:48.530",
        "Correct": 1,
        "Progress": 2,
        "UserId": 40281,
        "ExerciseId": 1029120,
        "Difficulty": "329.2341931",
        "Subject": "Begrijpend Lezen",
        "Domain": "-",
        "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
      },
    ];

    reportService.getStudentsData().subscribe(
      studentsData => {
        expect(studentsData).toEqual(expectedData, 'Failed expected students data');
        done();
      },
      done.fail
    );

    //getStudentsData() should have made one GET request
    const req = httpTestingController.expectOne('assets/data/work.json');
    expect(req.request.method).toEqual('GET');
    req.flush(expectedData);
  });
});

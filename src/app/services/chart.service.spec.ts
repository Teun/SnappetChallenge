import {TestBed} from '@angular/core/testing';

import {ChartService} from './chart.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {IPieChartModel} from "../models/IPieChartModel";

const MOCK_DATA = [
  {
    "SubmittedAnswerId": 2395278,
    "SubmitDateTime": "2015-03-25T07:35:38.740",
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
    "SubmitDateTime": "2015-03-25T07:36:48.530",
    "Correct": 1,
    "Progress": 2,
    "UserId": 40281,
    "ExerciseId": 1029120,
    "Difficulty": "329.2341931",
    "Subject": "Begrijpend Lezen",
    "Domain": "-",
    "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
  },
  {
    "SubmittedAnswerId": 2396638,
    "SubmitDateTime": "2015-03-25T07:36:55.487",
    "Correct": 1,
    "Progress": 0,
    "UserId": 40282,
    "ExerciseId": 1013670,
    "Difficulty": "-200",
    "Subject": "Begrijpend Lezen",
    "Domain": "-",
    "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
  },
  {
    "SubmittedAnswerId": 2396696,
    "SubmitDateTime": "2015-03-25T07:36:59.653",
    "Correct": 1,
    "Progress": 2,
    "UserId": 40281,
    "ExerciseId": 1029121,
    "Difficulty": "353.3972855",
    "Subject": "Begrijpend Lezen",
    "Domain": "-",
    "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
  },
  {
    "SubmittedAnswerId": 2397209,
    "SubmitDateTime": "2015-03-25T07:37:24.030",
    "Correct": 1,
    "Progress": 0,
    "UserId": 40285,
    "ExerciseId": 1038506,
    "Difficulty": "-200",
    "Subject": "Begrijpend Lezen",
    "Domain": "-",
    "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
  }
];

describe('GraphService', () => {
  let httpTestingController: HttpTestingController;
  let chartService: ChartService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    httpTestingController = TestBed.inject(HttpTestingController);
    chartService = TestBed.inject(ChartService);
  });

  afterEach(() => {
    httpTestingController.verify(); //Verifies that no requests are outstanding.
  });

  it('should create', () => {
    expect(chartService).toBeTruthy();
  });

  it('getLearningObjectivePieChartModel method should return IPieChartModel type object', () => {
    let returnV = chartService.getLearningObjectivePieChartModel(MOCK_DATA);
    expect(returnV).toBeTruthy(isIPieChartModel(returnV));
  });

  it('getSubjectPieChartModel method should return IPieChartModel type object', () => {
    let returnV = chartService.getLearningObjectivePieChartModel(MOCK_DATA);
    expect(returnV).toBeTruthy(isIPieChartModel(returnV));
  });

  it('getDomainPieChartModel method should return IPieChartModel type object', () => {
    let returnV = chartService.getLearningObjectivePieChartModel(MOCK_DATA);
    expect(returnV).toBeTruthy(isIPieChartModel(returnV));
  });

  function isIPieChartModel(object: any): object is IPieChartModel {
    return 'pieChartType' in object;
  }

});

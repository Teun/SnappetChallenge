import {ComponentFixture, TestBed} from '@angular/core/testing';

import {ReportComponent} from './report.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {MatCardModule} from "@angular/material/card";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule, MatOptionModule} from "@angular/material/core";
import {MatInputModule} from "@angular/material/input";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {of} from "rxjs";
import {ReportService} from "../services/report.service";
import {ChartsModule} from "ng2-charts";
import {MatSelectModule} from "@angular/material/select";
import {MatTableModule} from "@angular/material/table";

const MOCK_STUDENTS_DATA = [
  {
    "SubmittedAnswerId": 2395278,
    "SubmitDateTime": "2015-03-24T07:35:38.740",
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
    "SubmitDateTime": "2015-03-24T07:36:48.530",
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
    "SubmitDateTime": "2015-03-24T07:36:55.487",
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
    "SubmitDateTime": "2015-03-24T07:36:59.653",
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
    "SubmitDateTime": "2015-03-24T07:37:24.030",
    "Correct": 1,
    "Progress": 0,
    "UserId": 40285,
    "ExerciseId": 1038506,
    "Difficulty": "-200",
    "Subject": "Begrijpend Lezen",
    "Domain": "-",
    "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
  },
  {
    "SubmittedAnswerId": 2397600,
    "SubmitDateTime": "2015-03-24T07:37:43.500",
    "Correct": 0,
    "Progress": -10,
    "UserId": 40285,
    "ExerciseId": 1038509,
    "Difficulty": "230.6971675",
    "Subject": "Begrijpend Lezen",
    "Domain": "-",
    "LearningObjective": "Diverse leerdoelen Begrijpend Lezen"
  },
];

describe('ReportComponent', () => {
  let component: ReportComponent;
  let fixture: ComponentFixture<ReportComponent>;
  let reportService: any;
  let getStudentsDataSpy: any;

  beforeEach(async () => {
    reportService = jasmine.createSpyObj('ReportService', ['getStudentsData']);
    getStudentsDataSpy = reportService.getStudentsData.and.returnValue(of(MOCK_STUDENTS_DATA));
    await TestBed.configureTestingModule({
      declarations: [ReportComponent],
      imports: [
        HttpClientTestingModule,
        BrowserAnimationsModule,
        MatCardModule,
        MatFormFieldModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatInputModule,
        MatSelectModule,
        MatOptionModule,
        MatTableModule,
        FormsModule,
        ReactiveFormsModule,
        ChartsModule
      ],
      providers: [
        {provide: ReportService, useValue: reportService}
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportComponent);
    component = fixture.componentInstance;
  });

  afterEach(() => {
    fixture.destroy();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show graphs and a table after getStudentsData (spy done)', (done: DoneFn) => {
    fixture.detectChanges();

    // the spy's most recent call returns the observable with the mock employees
    getStudentsDataSpy.calls.mostRecent().returnValue.subscribe(() => {
      fixture.detectChanges();  // update view with mock data
      expect(component.learningObjectivePieChartModel).toBeDefined();
      expect(component.subjectPieChartModel).toBeDefined();
      expect(component.domainPieChartModel).toBeDefined();
      expect(fixture.nativeElement.querySelectorAll('canvas').length).toEqual(3);
      expect(fixture.nativeElement.querySelectorAll('table').length).toEqual(1);
      expect(fixture.nativeElement.querySelectorAll('tr').length).toEqual(4);
      done();
    });
  });

});

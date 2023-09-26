import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StudentService } from '../student.service';
import { StudentDetailsComponent } from './student-details.component';
import { of } from 'rxjs';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('StudentDetailsComponent', () => {
  let component: StudentDetailsComponent;
  let fixture: ComponentFixture<StudentDetailsComponent>;
  let studentService: StudentService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentDetailsComponent],
      imports: [HttpClientTestingModule, FormsModule],
      providers: [StudentService]
    });
    fixture = TestBed.createComponent(StudentDetailsComponent);
    component = fixture.componentInstance;
    studentService = TestBed.inject(StudentService);
    fixture.detectChanges();
  });

  //Student details component is created or not is checked
  it('should create student details component', () => {
    spyOn(studentService, 'getStudentDetails').and.returnValue(of(mockStudentsResponse));
    expect(component).toBeTruthy();
  });
  
  //Show details should fetch the correct details on call and update variables correctly
  it('Show details should be called and return correct output', () => {
    spyOn(studentService, 'getStudentDetails').and.returnValue(of(mockStudentsResponse));
    component.showDetails();
    expect(component.total).toEqual(2);
    expect(component.newdata).toEqual(mockStudentsResponseModified);
  });

  it('The student status should get updated correctly', () => {
    spyOn(studentService, 'getStudentDetails').and.returnValue(of(mockStudentsResponse));
    component.onDateChnge();
    component.showDetails();
    expect(component.total).toEqual(2);
    expect(component.currentStatus).toEqual("All Student's Progress on 0");
    expect(component.newdata).toEqual(mockStudentsResponseModified);
  });

  //Interface that defines the structure of each student record 
  interface StudentData {
    SubmittedAnswerId: Number;
    ExerciseId: Number;
    Difficulty: Number;
    Subject: String;
    LearningObjective: String;
    Correct: Number;
    SubmitDateTime: Date;
    Progress: Number;
    UserId: Number;
    Domain: String;
    Percent?: Number;
    Color?: String;
  }

  //Mock data to return by the student.service service
  const mockStudentsResponse:StudentData[] = [
    {
      SubmittedAnswerId: 123,
      ExerciseId: 234,
      Difficulty: 2,
      Subject: "Dutch",
      LearningObjective: "Learning",
      Correct: 1,
      SubmitDateTime: new Date('2015-03-02'),
      Progress: 1,
      UserId: 342,
      Domain: "-"
    },
    {
      SubmittedAnswerId: 183,
      ExerciseId: 934,
      Difficulty: 1,
      Subject: "English",
      LearningObjective: "Learning",
      Correct: 1,
      SubmitDateTime: new Date('2015-03-02'),
      Progress: 1,
      UserId: 567,
      Domain: "-"
    }
  ];

  //Mock data for newdata variable updated by function
  const mockStudentsResponseModified:StudentData[] = [
    {
      SubmittedAnswerId: 123,
      ExerciseId: 234,
      Difficulty: 2,
      Subject: "Dutch",
      LearningObjective: "Learning",
      Correct: 1,
      SubmitDateTime: new Date('2015-03-02'),
      Progress: 1,
      UserId: 342,
      Domain: "-",
      Percent: 1,
      Color: '#4CAF50'
    },
    {
      SubmittedAnswerId: 183,
      ExerciseId: 934,
      Difficulty: 1,
      Subject: "English",
      LearningObjective: "Learning",
      Correct: 1,
      SubmitDateTime: new Date('2015-03-02'),
      Progress: 1,
      UserId: 567,
      Domain: "-",
      Percent: 1,
      Color: '#4CAF50'
    }
  ];
});

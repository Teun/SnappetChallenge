import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StudentService } from '../student.service';
import { StudentComponent } from './student.component';
import { of } from 'rxjs';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('StudentComponent', () => {
  let component: StudentComponent;
  let fixture: ComponentFixture<StudentComponent>;
  let studentService: StudentService;
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentComponent],
      imports: [HttpClientTestingModule],
      providers: [StudentService],
    });
    fixture = TestBed.createComponent(StudentComponent);
    component = fixture.componentInstance;
    studentService = TestBed.inject(StudentService);
    fixture.detectChanges();
  });

  //This checks if the student component is created or not
  it('should student component create', ()=>{
    spyOn(studentService, 'getStudents').and.returnValue(of(mockStudentsResponse));
    expect(component).toBeTruthy();
  });

  //Mock data to be returned by the student/service service
  const mockStudentsResponse:number[] = [123,568,233];
});

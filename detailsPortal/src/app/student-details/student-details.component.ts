import { Component, Input, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
//Interface to define the student api details structure
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

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css'],
})
export class StudentDetailsComponent implements OnInit {
  newdata: StudentData[] = [];
  total: number = 0;
  currentD:String = '2015-03-18'; //Current Date is set here
  currentStatus = "All Student's Progress on " + this.currentD;

  @Input() data: any; //Student Id from student component fetched here
  constructor(private studentService: StudentService) {}

  //This function is used to return today's date [Predefind here]
  getToday(): string {
    //I want this date as today's date. 
    return new Date('2015-03-18').toISOString().split('T')[0];
  }

  //This function shows details like selected date and total selected records are shown
  showDetails(data: Number = 0, newDate: any = 0) {
    if (data == 0) {
      this.currentStatus = "All Student's Progress on " + newDate;
    } else {
      this.currentStatus = data + "'s Progress on " + newDate;
    }
    this.studentService
      .getStudentDetails(data, newDate) //This fetches the details of students by Date and Id
      .subscribe((result: any) => {
        this.newdata = [];
        result.map((data: StudentData) => {
          console.log(data);
          data.Color = '#4CAF50'; //Positive progress shown in green
          if (Number(data.Progress) < 0) {
            data.Percent = Number(data.Progress) * -1;
            data.Color = 'red'; //Negative progress shown in red
          } else {
            data.Percent = Number(data.Progress);
          }

          data.SubmitDateTime = new Date(data.SubmitDateTime); 
          this.newdata.push(data);
        });

        this.total = this.newdata.length;
      });
  }

 //On change of date from datepicker this function will be called
  onDateChnge() {
    if (this.data == 0) {
      this.currentStatus = "All Student's Progress on " + this.currentD;
    } else {
      this.currentStatus = this.data + "'s Progress on " + this.currentD;
    }
    this.showDetails(this.data, this.currentD);
  }

  //On change of student from sidebar this function will be called
  ngOnChanges() {
    this.showDetails(this.data, this.currentD); //Fetch and show new student details
  }
  ngOnInit(): void {}
}

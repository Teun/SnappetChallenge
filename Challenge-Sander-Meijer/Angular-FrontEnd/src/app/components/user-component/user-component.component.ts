import { Component, OnInit } from '@angular/core';
import { WorkResultService } from "app/services/work-result.service";
import { Observable } from "rxjs/Rx";
import { UserDto } from "app/dtos/user-dto";
import { WorkResultDto } from "app/dtos/work-result-dto";

@Component({
  selector: 'user-component',
  templateUrl: './user-component.component.html',
  styleUrls: ['./user-component.component.css']
})
export class UserComponentComponent implements OnInit {

  users: Observable<UserDto[]>;

  columns = [
    { name: 'submitDateTime' },
    { name: 'correct' },
    { name: 'userId' },
    { name: 'excerciseId' },
    { name: 'subject' },
    { name: 'domain' },
    { name: 'learningObjective' }
  ];


  ngOnInit(): void {
    this.users = this.WorkResultService.GetTodaysData();
  }


  constructor(
    private WorkResultService: WorkResultService
  ) { }

  GetCorrect(workResults: WorkResultDto[]): number {
    let counter = 0;
    workResults.forEach(element => {
      if (element.correct) {
        counter++
      }
    });
    return counter;
  }
}

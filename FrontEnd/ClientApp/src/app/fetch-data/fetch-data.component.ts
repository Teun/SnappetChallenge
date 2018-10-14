import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public workItems: WorkItem[];
  public subjects: string[];
  public subjectChosen: string;

  private http: HttpClient;
  private apiBaseUrl: string;
  private dateChosen: Date;

  constructor(http: HttpClient, @Inject('API_BASE_URL') apiBaseUrl: string) {
    this.http = http;
    this.apiBaseUrl = apiBaseUrl;

    var defaultDate = new Date(2015, 2, 24, 11, 30, 0);
    this.loadSubjects(defaultDate);
  }
    
  public loadWorkItems(subject: string) {
    this.subjectChosen = subject;

    this.http.get<WorkItem[]>(this.apiBaseUrl + 'api/work/' + subject + '/' + this.dateChosen.toISOString()).subscribe(result => {
      this.workItems = result;
    }, error => console.error(error));
  }
  
  public dateChange(event: MatDatepickerInputEvent<Date>) {
    this.dateChosen = event.value;

    this.loadSubjects(event.value);
  }

  private loadSubjects(date: Date) {
    // get the subjects for the provided day
    this.http.get<string[]>(this.apiBaseUrl + 'api/work/subjects/' + date.toISOString()).subscribe(result => {
      this.subjects = result;
    }, error => console.error(error));
  }
}

interface WorkItem {
  submittedAnswerId: number;
  correct: boolean;
  subject: string;
  progress: number;
  difficulty: string;
  learningObjective: string;
  userId: number;
  exerciseId: number;
}

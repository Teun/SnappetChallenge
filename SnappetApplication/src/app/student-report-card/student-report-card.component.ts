import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-report-card',
  templateUrl: './student-report-card.component.html',
  styleUrls: ['./student-report-card.component.scss']
})
export class StudentReportCardComponent implements OnInit {

  @Input() student: any;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  gotoStudentDetail(){
    this.router.navigate(['/results', this.student.id]);
  }

  getImageSrc() {
    return `../../assets/${this.student.id}.png`;
  }

}

import { Component, OnInit } from '@angular/core';
import { StudentWorkItem } from 'src/app/Interfaces/StudentWorkItem';
import { WorkResultsServiceService } from '../../services/work-results-service.service';

@Component({
  selector: 'app-student-overview',
  templateUrl: './student-overview.component.html',
  styleUrls: ['./student-overview.component.scss']
})
export class StudentOverviewComponent implements OnInit {
  studentWorkItems!: StudentWorkItem[];

  constructor(private workResultsServiceService: WorkResultsServiceService) { }

  ngOnInit(): void {
  }

  filterResults(studentId: number){
    this.workResultsServiceService.getStudentOverview(studentId).subscribe((result) => {
      this.studentWorkItems = result
    })
  }
}

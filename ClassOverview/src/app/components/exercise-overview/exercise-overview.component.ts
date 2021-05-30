import { Component, OnInit } from '@angular/core';
import { StudentWorkItem } from 'src/app/Interfaces/StudentWorkItem';
import { WorkResultsServiceService } from '../../services/work-results-service.service';

@Component({
  selector: 'app-exercise-overview',
  templateUrl: './exercise-overview.component.html',
  styleUrls: ['./exercise-overview.component.scss']
})
export class ExerciseOverviewComponent implements OnInit {
  studentWorkItems!: StudentWorkItem[];
  difficulty!: string;
  learningObjective!: string;
  subject!: string;
  domain!: string;

  constructor(private workResultsServiceService: WorkResultsServiceService) { }

  ngOnInit(): void {
  }

  filterResults(exerciseId: number) {
    this.workResultsServiceService.getExerciseOverview(exerciseId).subscribe((result) => {
      if (result.length > 0) {
        this.studentWorkItems = result
        this.difficulty = result[0].difficulty;
        this.learningObjective = result[0].learningObjective;
        this.subject = result[0].subject;
        this.domain = result[0].domain;
      }
    })
  }
}

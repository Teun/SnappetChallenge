import { Component, OnInit } from '@angular/core';
import { WorkResultsServiceService } from '../../services/work-results-service.service';
import { ExerciseItem } from '../../Interfaces/ExerciseItem'

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.scss']
})
export class ExerciseListComponent implements OnInit {
  exerciseItems!: ExerciseItem[];

  constructor(private workResultsServiceService: WorkResultsServiceService) { }

  ngOnInit(): void {
    this.workResultsServiceService.getExerciseList().subscribe((result) => {
      this.exerciseItems = result
    })
  }
}

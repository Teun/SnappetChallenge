import { Injectable } from '@angular/core';
import { StudentWorkItem } from '../Interfaces/StudentWorkItem'
import { ExerciseItem } from '../Interfaces/ExerciseItem'
import { Observable } from 'rxjs'
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class WorkResultsServiceService {
  private apiUrl = "https://localhost:5001/StudentsWork"

  constructor(private httpClient: HttpClient) { }

  getStudentOverview(studentId: number): Observable<StudentWorkItem[]> {
    return this.httpClient.get<StudentWorkItem[]>(`${this.apiUrl}/getStudentOverview?id=${studentId}`)
  }

  getExerciseOverview(exerciseId: number): Observable<StudentWorkItem[]> {
    return this.httpClient.get<StudentWorkItem[]>(`${this.apiUrl}/getExerciseOverview?id=${exerciseId}`)
  }

  getExerciseList(): Observable<ExerciseItem[]> {
    return this.httpClient.get<ExerciseItem[]>(`${this.apiUrl}/GetExercises`)
  }
}

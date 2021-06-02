import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Work } from '../types/work.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(
    private http: HttpClient
  ) { }

  createDataBackend() {
    return this.http.get<Work[]>('http://localhost:3000/work').pipe(tap(work => {
      this.createDataSubjects(work);
      this.createDataDomains(work);
      this.createDataLearningObjectives(work);
      this.createDataExercises(work);
    }));
  }

  private createDataSubjects(work: Work[]) {
    this.http.get<any>('http://localhost:3000/subjects').subscribe((results: any) => {
      if (results.length === 0) {
        const subjects = [...new Set(work.map(workResult => workResult.subject))];
        subjects.forEach((subject, index) => {
          const domains = [...new Set(work
            .filter(workResult => workResult.subject === subject)
            .map(workResult => workResult.domain)
          )];
          const learningObjectives = [...new Set(work
            .filter(workResult => workResult.subject === subject)
            .map(workResult => workResult.learningObjective)
          )];
          const exercises = [...new Set(work
            .filter(workResult => workResult.subject === subject)
            .map(workResult => workResult.exerciseId)
          )];
          this.http.post<any>('http://localhost:3000/subjects', { id: index + 1, name: subject, domains, learningObjectives, exercises }).subscribe(() => { })
        })
      }
    })
  }

  private createDataDomains(work: Work[]) {
    this.http.get<any>('http://localhost:3000/domains').subscribe((results: any) => {
      if (results.length === 0) {
        const domains = [...new Set(work.map(workResult => workResult.domain))];
        domains.forEach((domain, index) => {
          const subjects = [...new Set(work
            .filter(workResult => workResult.domain === domain)
            .map(workResult => workResult.subject)
          )];
          const learningObjectives = [...new Set(work
            .filter(workResult => workResult.domain === domain)
            .map(workResult => workResult.learningObjective)
          )];
          const exercises = [...new Set(work
            .filter(workResult => workResult.domain === domain)
            .map(workResult => workResult.exerciseId)
          )];
          this.http.post<any>('http://localhost:3000/domains', { id: index + 1, name: domain, subjects, learningObjectives, exercises }).subscribe(() => { })
        })
      }
    })
  }

  private createDataLearningObjectives(work: Work[]) {
    this.http.get<any>('http://localhost:3000/learningObjectives').subscribe((results: any) => {
      if (results.length === 0) {
        const learningObjectives = [...new Set(work.map(workResult => workResult.learningObjective))];
        learningObjectives.forEach((learningObjective, index) => {
          const subjects = [...new Set(work
            .filter(workResult => workResult.learningObjective === learningObjective)
            .map(workResult => workResult.subject)
          )];
          const domains = [...new Set(work
            .filter(workResult => workResult.learningObjective === learningObjective)
            .map(workResult => workResult.domain)
          )];
          const exercises = [...new Set(work
            .filter(workResult => workResult.learningObjective === learningObjective)
            .map(workResult => workResult.exerciseId)
          )];
          this.http.post<any>('http://localhost:3000/learningObjectives', { id: index + 1, name: learningObjective, subjects, domains, exercises }).subscribe(() => { })
        })
      }
    })
  }

  private createDataExercises(work: Work[]) {
    this.http.get<any>('http://localhost:3000/exercises').subscribe((results: any) => {
      if (results.length === 0) {
        const exercises = [...new Set(work.map(workResult => workResult.exerciseId))];
        exercises.forEach((exercise, index) => {
          const subjects = [...new Set(work
            .filter(workResult => workResult.exerciseId === exercise)
            .map(workResult => workResult.subject)
          )];
          const domains = [...new Set(work
            .filter(workResult => workResult.exerciseId === exercise)
            .map(workResult => workResult.domain)
          )];
          const learningObjectives = [...new Set(work
            .filter(workResult => workResult.exerciseId === exercise)
            .map(workResult => workResult.learningObjective)
          )];
          this.http.post<any>('http://localhost:3000/exercises', { id: index + 1, name: exercise, subjects, domains, learningObjectives }).subscribe(() => { })
        })
      }
    })
  }
}

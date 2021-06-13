import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forkJoin } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Work } from '../types/work.interface';
import { WorkResult } from '../types/work-result.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  currentDateTime: string = '2015-03-24T11:30:00.000';
  workResults: Array<WorkResult> = [];

  constructor(
    private http: HttpClient
  ) { 
    this.getWork('', '', '', '').subscribe(() => {});
  }

  initGet() {
    return forkJoin([
      this.http.get<any>(`http://localhost:3000/subjects`).pipe(
        map(subjects => subjects.map((subject: any) => subject.name))
      ),
      this.http.get<any>(`http://localhost:3000/domains`).pipe(
        map(domains => domains.map((domain: any) => domain.name))
      ),
      this.http.get<any>(`http://localhost:3000/learningObjectives`).pipe(
        map(learningObjectives => learningObjectives.map((learningObjective: any) => learningObjective.name))
      ),
      this.http.get<any>(`http://localhost:3000/exercises`).pipe(
        map(exercises => exercises.map((exercise: any) => exercise.name))
      )
    ])
  }

  getSubject(subject: string) {
    if (subject === '') {
      return this.http.get<any>(`http://localhost:3000/subjects`);
    } else {
      return this.http.get<any>(`http://localhost:3000/subjects?name=${subject}`);
    }
  }

  getDomain(domain: string) {
    if (domain === '') {
      return this.http.get<any>(`http://localhost:3000/domains`);
    } else {
      return this.http.get<any>(`http://localhost:3000/domains?name=${domain}`);
    }
  }

  getLearningObjective(learningObjectives: string) {
    if (learningObjectives === '') {
      return this.http.get<any>(`http://localhost:3000/learningObjectives`);
    } else {
      return this.http.get<any>(`http://localhost:3000/learningObjectives?name=${learningObjectives}`);
    }
  }

  getExercise(exercise: string) {
    if (exercise === '') {
      return this.http.get<any>(`http://localhost:3000/exercises`);
    } else {
      return this.http.get<any>(`http://localhost:3000/exercises?name=${exercise}`);
    }
  }

  getWork(subject: string, domain: string, learningObjective: string, exercise: string) {
    const subjectUrl = subject ? `?subject=${subject}` : ``;
    const domainUrl = domain ? `?domain=${domain}` : ``;
    const learningObjectiveUrl = learningObjective ? `?learningObjective=${learningObjective}` : ``;
    const exerciseUrl = exercise ? `?exercise=${exercise}` : ``;
    const urlExtent = subjectUrl + domainUrl + learningObjectiveUrl + exerciseUrl;
    return this.http.get<Work[]>('http://localhost:3000/work' + urlExtent).pipe(tap((works: Work[]) => {
      this.workResults = [];
      this.workResults.push(this.numStudents(works));
      this.workResults.push(this.numberOfDoneExercises(works));
      this.workResults.push(this.percentageCorrectExercises(works));
      this.workResults.push(this.averageProgress(works));
      this.workResults.push(this.averageDifficulty(works));
    }));
  }

  private numStudents(works: Work[]) {
    const numStudents = [...new Set(works
      .filter(work => work.submitDateTime <= this.currentDateTime)
      .map(work => work.userId)
    )].length;
    return { name: 'Aantal studenten aan het werk: ', value: numStudents };
  }

  private numberOfDoneExercises(works: Work[]) {
    const numberOfDoneExercises = works.filter(work => work.submitDateTime <= this.currentDateTime).length;
    return { name: 'Aantal afgeronde oefeningen: ', value: numberOfDoneExercises };
  }

  private percentageCorrectExercises(works: Work[]) {
    const numCorrectAnswers = works.filter(work => work.submitDateTime <= this.currentDateTime && work.correct === 1).length;
    const numWrongAnswers = works.filter(work => work.submitDateTime <= this.currentDateTime && work.correct === 0).length;
    const value: string = (numCorrectAnswers/(numCorrectAnswers + numWrongAnswers)*100).toFixed(0) + '%'
    return { name: 'Percentage oefeningen die correct zijn: ', value };
  }

  private averageProgress(works: Work[]) {
    const workWithProgress = works.filter(work => work.submitDateTime <= this.currentDateTime && work.progress !== 0);
    let totProgress: number = 0;
    workWithProgress.forEach(work => {
      totProgress += work.progress;
    });
    const value: string = (totProgress / workWithProgress.length).toFixed(1);
    return { name: 'Gemiddelde voortgang van de leerlingen: ', value };
  }

  private averageDifficulty(works: Work[]) {
    const currentWorks = works.filter(work => work.submitDateTime <= this.currentDateTime);
    let numWork = currentWorks.length;
    let totDifficulty: number = 0;
    currentWorks.forEach(work => {
      if (work.difficulty !== 'NULL') {
        totDifficulty += Number(work.difficulty);
      } else {
        numWork--;
      }
    });
    const value = (totDifficulty / numWork).toFixed(1);
    return { name: 'Gemiddelde moeilijkheid: ', value };
  }

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

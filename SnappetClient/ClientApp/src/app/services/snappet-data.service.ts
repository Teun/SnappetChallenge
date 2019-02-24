import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppConfig } from '../app-config';
import { LearningSubject } from '../interfaces/learning-subject';
import { LearningDomain } from '../interfaces/learning-domain';
import { LearningObjective } from '../interfaces/learning-objective';
import { LearningData } from '../interfaces/learning-data';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SnappetDataService {

    uri: string;
    currentDate: Date;
    public learningSubjects: LearningSubject[];
    public behaviorSubject: BehaviorSubject<LearningSubject[]> = new BehaviorSubject<LearningSubject[]>([]);
    public data = this.behaviorSubject.asObservable();

    constructor(private httpClient: HttpClient) {
        this.uri = AppConfig.settings.SnappetUrl;
        this.currentDate = AppConfig.settings.CurrentDate;
        this.getData(); // ? cannot be moved to ngInit since this method is not called
    }

    private getData(): void {
        this.httpClient.get<LearningSubject[]>(this.uri, { params: this.getHttpParams() }).subscribe(result => {
            this.learningSubjects = result; // save data locally
            this.behaviorSubject.next(this.learningSubjects); // push data
        }, error => console.error(error));
    }

    private getHttpParams(): HttpParams
    {
        return new HttpParams().set('maxDateTime', this.currentDate.toString());
    }

    public getSubject(name: string): LearningSubject {
        var myIndex = this.learningSubjects.findIndex(x => x.name === name);
        return this.learningSubjects[myIndex];
    }
}

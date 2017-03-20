import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Subject } from './subject';
import { SubjectStatistics } from './subjectstatistics';

@Injectable()
export class WorkService {
    constructor(private http: Http) {
    }

    public getSubjects(): Promise<Subject[]> {
        return this.http.get('api/work/subjects')
            .toPromise()
            .then((r: Response) => r.json() as Subject[]);
    }

    public getSubject(subject: string): Promise<SubjectStatistics> {
        return this.http.get(`api/work/subjects/${subject}`)
            .toPromise()
            .then((r: Response) => r.json() as SubjectStatistics);
    }
}

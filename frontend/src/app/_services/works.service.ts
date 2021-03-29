import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Work from '../_models/works.model';
import { toJSONLocal } from '../_utils/date.utils';
import { removeEmpty } from '../_utils/object.utils';
import { Observable } from 'rxjs';
import { ApiHelper } from '../_utils/api.utils';

@Injectable({
    providedIn: 'root'
})
export class WorksService {

    constructor(private http: HttpClient) {
    }

    public prepareFilters(formData: Work): Work {
        formData.startdate = toJSONLocal(formData.startdate);
        formData.enddate = toJSONLocal(formData.enddate);
        return removeEmpty(formData);
    }

    public getActivities(params = {}): Observable<Work[]> {
        return this.http.get<Work[]>(ApiHelper.get('activity'), { params });
    }

    public getExercises(params = {}): Observable<Work[]> {
        return this.http.get<Work[]>(ApiHelper.get('exercises'), { params });
    }

    public getProgress(params = {}): Observable<Work[]> {
        return this.http.get<Work[]>(ApiHelper.get('progress'), { params });
    }

    public getUsers(params = {}): Observable<Work[]> {
        return this.http.get<Work[]>(ApiHelper.get('users'), { params });
    }

    public getWorks(params = {}): Observable<Work[]> {
        return this.http.get<Work[]>(ApiHelper.root(), { params });
    }

}

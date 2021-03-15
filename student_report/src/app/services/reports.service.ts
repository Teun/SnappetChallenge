import { Injectable } from '@angular/core';
import { IStudentData } from '../models/IStudentData';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  studentData: IStudentData[] = [];//SampleData.js as IStudentData[];
  constructor(private http: HttpClient) {
  }

  getAllStudentData(): Observable<IStudentData[]> {
    return this.http.get<IStudentData[]>('../../assets/work.json');
  }
}
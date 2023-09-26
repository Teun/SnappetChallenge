import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from '../environments/environment'
@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient){

  }

  //This service fetches unique list of srudents
  getStudents(){
    return this.http.get(environment.apiUrl+'/students')
  }

  //This service fetches the details of student by calling node api
  getStudentDetails(studentId:Number = 0,newDate:any = 0){
    return this.http.get(environment.apiUrl+'/students/details?id='+studentId+'&dates='+newDate)
  }
}

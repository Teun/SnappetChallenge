import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

import { DataService } from '../../services/dataService';
import { StudentDetailPage } from '../student-detail/student-detail';


@Component({
  selector: 'page-students',
  templateUrl: 'students.html',
})
export class StudentsPage {

  students: number[];
  dataReady: boolean;

  constructor(public navCtrl: NavController, private dataService: DataService) {
  }

  ionViewCanEnter() {
    return new Promise((resolve) => {
      this.dataService.getStudents().subscribe(result => {
        this.students = result;
        this.dataReady = true;
        resolve();
      });
    });
  }

  studentClicked(studentId: number) {
    this.navCtrl.push(StudentDetailPage, { studentId: studentId });
  }
}
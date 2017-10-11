import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { DataService } from '../../services/dataService';
import { StudentResult } from '../../models/studentResult';

@Component({
  selector: 'page-student-detail',
  templateUrl: 'student-detail.html'
})
export class StudentDetailPage {

  studentId: number;
  studentResults: StudentResult[];
  dataReady: boolean;

  constructor(public navCtrl: NavController, public navParams: NavParams, private dataService: DataService) {
    this.studentId = this.navParams.get('studentId');
  }

  ionViewCanEnter() {
    return this.retrieveData();
  }

  retrieveData(): any {
    this.dataReady = false;
    return new Promise((resolve, reject) => {
      this.dataService.getStudentResults(this.studentId).subscribe(result => {
        this.studentResults = result;
        this.dataReady = true;
        resolve();
      });
    });
  }
}
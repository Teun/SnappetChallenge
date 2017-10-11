import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

import { DataService } from '../../services/dataService';
import { LearningObjective } from '../../models/learningObjective';

import { LearningObjectivePage } from './../learning-objective/learning-objective';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  learningObjectives: LearningObjective[];
  dataReady: boolean;

  constructor(public navCtrl: NavController, private dataService: DataService) {
    this.dataReady = false;
  }

  ionViewCanEnter() {
    return this.retrieveData();
  }

  retrieveData(): any {
    this.dataReady = false;
    return new Promise((resolve, reject) => {
      this.dataService.getLearningObjectives().subscribe(result => {
        this.learningObjectives = result;
        this.dataReady = true;
        resolve();
      });
    });
  }

  objectiveClicked(learningObjective: LearningObjective) {
    this.navCtrl.push(LearningObjectivePage, { learningObjective: learningObjective });
  }
}

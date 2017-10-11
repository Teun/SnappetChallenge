import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';

import { LearningObjective } from '../../models/learningObjective';
import { Exercise } from '../../models/exercise';

@Component({
  selector: 'page-learning-objective',
  templateUrl: 'learning-objective.html',
})
export class LearningObjectivePage {

  learningObjective: LearningObjective;
  hardestExercises: Exercise[];

  constructor(public navCtrl: NavController, public navParams: NavParams) {
    this.learningObjective = this.navParams.get('learningObjective');
    this.hardestExercises = this.learningObjective.Exercises.sort((e1, e2) => (e1.NrAnsweredCorrectly / e1.NrAnswered) - (e2.NrAnsweredCorrectly / e2.NrAnswered));
  }

  percentageRight(): number {
    var nrAnswered = 0;
    var nrAnsweredCorrectly = 0;
    for (let exercise of this.learningObjective.Exercises) {
      nrAnswered += exercise.NrAnswered;
      nrAnsweredCorrectly += exercise.NrAnsweredCorrectly;
    }

    return nrAnsweredCorrectly / nrAnswered;
  }

  hardestExercise(): Exercise {
    var exercise = this.learningObjective.Exercises[0];
    for (let ex of this.learningObjective.Exercises) {
      if (ex.NrAnsweredCorrectly / ex.NrAnswered < exercise.NrAnsweredCorrectly / exercise.NrAnswered) {
        exercise = ex;
      }
    }

    return exercise;
  }
}
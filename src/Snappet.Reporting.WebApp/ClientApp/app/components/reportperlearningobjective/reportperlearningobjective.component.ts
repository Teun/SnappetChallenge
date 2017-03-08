import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'reportperlearningobjective',
    templateUrl: './reportperlearningobjective.component.html'
})
export class ReportPerLearningObjectiveComponent {
    public correctAnswersPerLearningObjective: CorrectAnswersPerLearningObjective[];
    private baseUrl: string = 'http://localhost:5000';
     
    constructor(http: Http) {
        http.get(this.baseUrl + '/reports/CorrectAnswersPerLearningObjective?date=2015-03-24T00:00:00Z').subscribe(result => {
            this.correctAnswersPerLearningObjective = result.json() as CorrectAnswersPerLearningObjective[];
        });
    }
}

interface CorrectAnswersPerLearningObjective {
    subject: string;
    learningObjective: string;
    count: number;
    total: number;
    percentage: number;
}

import { Component, OnInit, OnDestroy } from '@angular/core';
import { LearningSubject } from '../interfaces/learning-subject';
import { LearningDomain } from '../interfaces/learning-domain';
import { LearningObjective } from '../interfaces/learning-objective';
import { LearningData } from '../interfaces/learning-data';
import { SnappetDataService } from '../services/snappet-data.service';
import { Subscription } from 'rxjs';


@Component({
    selector: 'app-learning-result',
    templateUrl: './learning-result.component.html',
    styleUrls: ['./learning-result.component.css']
})

export class LearningResultComponent implements OnInit, OnDestroy {

    public learningSubjects: LearningSubject[];
    private subscription: Subscription;

    constructor(private dataService: SnappetDataService) {
    }

    ngOnInit() {
        this.subscription = this.dataService.data.subscribe(data => this.learningSubjects = data);
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}

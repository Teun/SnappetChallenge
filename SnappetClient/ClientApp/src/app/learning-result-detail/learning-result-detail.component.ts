import { Component, OnInit, OnDestroy} from '@angular/core';
import { Router } from '@angular/router';
import { LearningSubject } from '../interfaces/learning-subject';
import { LearningDomain } from '../interfaces/learning-domain';
import { LearningObjective } from '../interfaces/learning-objective';
import { LearningData } from '../interfaces/learning-data';
import { SnappetDataService } from '../services/snappet-data.service';
import { ActivatedRoute } from '@angular/router';




@Component({
  selector: 'app-learning-result-detail',
  templateUrl: './learning-result-detail.component.html',
  styleUrls: ['./learning-result-detail.component.css']
})
export class LearningResultDetailComponent implements OnInit, OnDestroy {
    name: string;
    sub: any;
    learningSubject: LearningSubject;
    index: number = -1;
    activeDomain: LearningDomain;

    constructor(private route: ActivatedRoute, private dataService: SnappetDataService)
    {
    }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.name = params['name'];
        });
        this.learningSubject = this.dataService.getSubject(this.name);
        this.showNextDomain();

        // debug
        var str = JSON.stringify(this.learningSubject);
        console.log(str);
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    showNextDomain() : void
    {
        this.setIndex();
        this.activeDomain = this.learningSubject.domains[this.index];
    }

    setIndex(): void
    {
        if (this.index < this.learningSubject.domains.length - 1)
        {
            this.index += 1;
        }
        else
        {
            this.index = 0;
        }
    }

}

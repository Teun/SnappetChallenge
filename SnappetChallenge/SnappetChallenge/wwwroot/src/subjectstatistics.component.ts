import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ToasterService } from 'angular2-toaster';
import { Observable } from 'rxjs';

import { DomainStatistics } from './domainstatistics';
import { LearningObjectiveStatistics } from './learningobjectivestatistics';
import { SubjectStatistics } from './subjectstatistics';
import { WorkService } from './work.service';

@Component({
    selector: 'sc-subjectstatistics',
    templateUrl: 'src/subjectstatistics.component.html',
})
export class SubjectStatisticsComponent implements OnInit {
    public subject: SubjectStatistics;

    public pieLabels: string[] = ['Correct', 'Incorrect'];
    public pieColors: any[] = [{
            backgroundColor: ['rgba(0, 150, 0, 1)', 'rgba(150, 0, 0, 1)'],
        }];
    public pieChartOptions: any = {
        legend: {
            display: false,
        },
    };

    constructor(private workService: WorkService,
                private toasterService: ToasterService,
                private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            this.getSubject(params['subject']);
        });
    }

    public goBack(): void {
        window.history.back();
    }

    private getSubject(subject: string): void {
        this.workService.getSubject(subject)
            .then((subject: SubjectStatistics) => this.subject = subject)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        this.toasterService.pop('error', 'Vak konden niet worden geladen', error);
        return Promise.reject(error.message || error);
    }
}

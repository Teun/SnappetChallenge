import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToasterService } from 'angular2-toaster';
import { Observable } from 'rxjs';

import { Subject } from './subject';
import { WorkService } from './work.service';

@Component({
    selector: 'sc-progress',
    templateUrl: 'src/progress.component.html',
})
export class ProgressComponent implements OnInit {
    public radarChartLabels: string[];
    public radarChartData: any;
    public radarChartOptions: any = {
        legend: {
            position: 'right',
        },
        scale: {
            ticks: {
                suggestedMax: 5,
                suggestedMin: -5,
            },
        },
    };

    constructor(private workService: WorkService,
                private toasterService: ToasterService) {
    }

    public ngOnInit(): void {
        this.getSubjects();
    }

    private getSubjects(): void {
        this.workService.getSubjects()
            .then((subjects: Subject[]) => this.fillChart(subjects))
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        this.toasterService.pop('error', 'Vakken konden niet worden geladen', error);
        return Promise.reject(error.message || error);
    }

    private fillChart(subjects: Subject[]): void {
        this.radarChartLabels = subjects.map((l) => l.name);

        this.radarChartData = [{
            data: subjects.map((subject) => subject.averageProgress),
            label: 'Vaardigheid',
            lineTension: 0.2,
        }];
    }
}

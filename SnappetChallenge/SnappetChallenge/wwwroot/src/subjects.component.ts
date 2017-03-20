import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToasterService } from 'angular2-toaster';
import { Observable } from 'rxjs';

import { Subject } from './subject';
import { WorkService } from './work.service';

@Component({
    selector: 'sc-subjects',
    templateUrl: 'src/subjects.component.html',
})
export class SubjectsComponent implements OnInit {
    public subjects: Subject[];

    constructor(private workService: WorkService,
                private toasterService: ToasterService,
                private router: Router) {
    }

    public ngOnInit(): void {
        this.getSubjects();
    }

    public gotoDetail(subject: string): void {
        this.router.navigate(['/subjects', subject]);
    }

    private getSubjects(): void {
        this.workService.getSubjects()
            .then((subjects: Subject[]) => this.subjects = subjects)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        this.toasterService.pop('error', 'Vakken konden niet worden geladen', error);
        return Promise.reject(error.message || error);
    }
}

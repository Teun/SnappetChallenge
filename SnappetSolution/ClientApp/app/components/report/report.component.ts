import { Component } from '@angular/core';
import { WorkResultService } from '../../services/work-results.service';
import { ClassModel } from '../../models/ClassModel';
import { StudentModel } from '../../models/StudentModel';

@Component({
    selector: 'report',
    templateUrl: './report.component.html',
    styleUrls: ['./report.component.css']
})
export class ReportComponent {

    public classModel: ClassModel;
    public IndivExpanded: boolean;
    public TotalExpanded: boolean = true;

    constructor(private _workResultService: WorkResultService) { }

    ngOnInit() {
        this._workResultService.getWorkResult().subscribe(result => {
            this.classModel = result.json() as ClassModel;
            console.log(this.classModel);
        }, error => console.error(error));
    }

    convertToPercent(value: number): string {
        return value + "%";
    }

    isNegativeProgress(progress: number): boolean {
        return progress < 0;
    }

    getBestStudents(subjectStudents: Array<StudentModel>, count: number = 1): Array<StudentModel> {
        return subjectStudents.slice(0, count);
    }

    getPositiveValue(value: number): number {
        return Math.abs(value);
    }

    indivExpand() {
        this.IndivExpanded = !this.IndivExpanded;        
    }

    totalExpand() {
        this.TotalExpanded = !this.TotalExpanded;
    }
}
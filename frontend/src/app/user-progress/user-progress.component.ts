import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Color, Label } from 'ng2-charts';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { WorksService } from '../_services/works.service';
import Work from '../_models/works.model';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app-user-progress',
    templateUrl: './user-progress.component.html',
    styleUrls: ['./user-progress.component.scss']
})
export class UserProgressComponent implements OnInit {

    public usersList: Work[] = [];
    public params: FormGroup;
    public maxDate;
    public labels: Label[] = [];
    public progress: ChartDataSets[] = [
        { data: [], label: 'Progress' },
    ];
    public lineChartOptions: (ChartOptions & { annotation: any }) = environment.chartSettings.lineChartOptions;
    public lineChartColors: Color[] = environment.chartSettings.lineChartColors;

    constructor(private worksService: WorksService,
                private formBuilder: FormBuilder
    ) {
        this.maxDate = new Date('2015-03-24 11:30:00 UTC');
        this.params = this.createFormFields();
    }

    ngOnInit(): void {
        this.getUsersList();
    }

    private getFilterValues(): Work {
        return this.worksService.prepareFilters({ ...this.params.value });
    }

    private getUsersList(): void {
        this.worksService.getUsers()
            .subscribe(data => {
                this.usersList = data;
            });
    }

    private getProgress(filters = {}): void {
        // reset data
        this.progress[0].data = [];
        this.labels = [];
        // get new data
        this.worksService.getProgress(filters)
            .subscribe(data => {
                data.forEach(entry => {
                    if (entry.Progress != null) {
                        // @ts-ignore
                        this.progress[0].data.push(entry.Progress);
                    }
                    if (entry.UserId != null) {
                        this.labels.push(entry.UserId.toString());
                    }
                });
            });
    }

    private createFormFields(): FormGroup {
        return this.formBuilder.group({
            UserId: new FormControl(),
            // starting from two days ago
            startdate: new FormControl(new Date('2015-03-22 11:30:00 UTC')),
            enddate: new FormControl(this.maxDate),
        });
    }

    public filter($event: Event): void {
        $event.preventDefault();
        const filters = this.getFilterValues();
        if (typeof filters.UserId !== 'undefined' && filters.UserId) {
            this.getProgress(filters);
        }
    }

}

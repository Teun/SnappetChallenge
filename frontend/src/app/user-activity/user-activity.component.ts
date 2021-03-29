import { Component, OnInit } from '@angular/core';
import { WorksService } from '../_services/works.service';
import { Color, Label } from 'ng2-charts';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import Work from '../_models/works.model';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app-user-activity',
    templateUrl: './user-activity.component.html',
    styleUrls: ['./user-activity.component.scss']
})
export class UserActivityComponent implements OnInit {

    public params: FormGroup;
    public maxDate;
    public labels: Label[] = [];
    public activities: ChartDataSets[] = [
        { data: [], label: 'Activities' },
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
        this.getActivities(this.getFilterValues());
    }

    private getFilterValues(): Work {
        return this.worksService.prepareFilters({ ...this.params.value });
    }

    private getActivities(filters = {}): void {
        // reset data
        this.activities[0].data = [];
        this.labels = [];
        // get new data
        this.worksService.getActivities(filters)
            .subscribe(data => {
                data.forEach(entry => {
                    if (entry.ActivityCount != null) {
                        // @ts-ignore
                        this.activities[0].data.push(entry.ActivityCount);
                    }
                    if (entry.UserId != null) {
                        this.labels.push(entry.UserId.toString());
                    }
                });
            });
    }

    private createFormFields(): FormGroup {
        return this.formBuilder.group({
            // starting from a week ago
            startdate: new FormControl(new Date('2015-03-17 11:30:00 UTC')),
            enddate: new FormControl(this.maxDate),
        });
    }

    public filter($event: Event): void {
        $event.preventDefault();
        const filters = this.getFilterValues();
        this.getActivities(filters);
    }

}

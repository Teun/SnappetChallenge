import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'reporting',
    templateUrl: './reporting.component.html'
})

export class ReportingComponent {
    public selectedReport: string = null;
    public selectedDate: string = "2015-03-24T11:30:00";
    public reports: Array<IReport>;
    public reportResult: IReportResult;

    constructor(private http: Http) {

    }

    ngOnInit() {
        this.http.get('/api/v1/reporting/getreports').subscribe(result => {
            this.reports = result.json() as Array<IReport>;
        });
    }

    public executeReport() {
        if (this.selectedReport) {
            const params = [{ key: "dateFrom", value: this.selectedDate }];

            this.http.post('/api/v1/reporting/executereport/' + this.selectedReport, params).subscribe(result => {
                this.reportResult = result.json() as IReportResult;
            });
        }
    }

    public onChange(value: string) {
        this.selectedReport = value;
        this.executeReport();
    }
}

interface IReportResult {
    displayName: string;
    columns: Array<string>;
    rows: Array<Array<string>>;
}

interface IReport {
    id: number;
    displayName: string;
}


import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'chartpersubject',
    templateUrl: './chartpersubject.component.html'
})
export class ChartPerSubjectComponent {
    public barChartOptions: any = {
        scaleShowVerticalLines: false,
        responsive: true
    };
    public barChartLabels: string[] = [];
    public barChartType: string = 'bar';
    public barChartLegend: boolean = true;

    public barChartData: any[] = [
        { data: [], label: 'Gisteren' },
        { data: [], label: 'Vandaag' }
    ];

    private baseUrl: string = 'http://localhost:5000';
     
    constructor(http: Http) {
        var yesterday = new Date(Date.UTC(2015, 2, 23));
        var today = new Date(Date.UTC(2015, 2, 24));

        this.getCorrectAnswersPerSubject(http, yesterday, true).then(data => {
            //buggie in Angular, update barChartData.data doesn't update the bar. We need to set a new barChartData object
            //so we clone the current one
            let clone = JSON.parse(JSON.stringify(this.barChartData));
            //update the first bar
            clone[0].data = data;
            //get data for the next bar
            this.getCorrectAnswersPerSubject(http, today, false).then(data => {
                clone[1].data = data;
                //and finally set a new barChartData
                this.barChartData = clone;
            });
        });

    }

    private getCorrectAnswersPerSubject(http: Http, date: Date, setLabels: boolean) {
        return new Promise(resolve => {
            http.get(this.baseUrl + '/reports/CorrectAnswersPerSubject?date=' + date.toJSON()).subscribe(result => {
                var subjects = result.json() as CorrectAnswersPerSubject[];

                //we only need percentages, extract them to a new array
                var percentages = [];
                for (var i = 0; i < subjects.length; i++) {
                    percentages.push((subjects[i].percentage * 100).toFixed(2));
                    if (setLabels) {
                        this.barChartLabels.push(subjects[i].subject);
                    }
                }
                resolve(percentages);
            });
        });
    }
}

interface CorrectAnswersPerSubject {
    subject: string;
    count: number;
    total: number;
    percentage: number;
}

import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { WorkItem } from '../../interfaces/work-item';
import { WorkSearchResults } from '../../interfaces/work-search-results';
import { WorkSearchComponent } from './work-search.component';
import { WorkSearchResultsComponent } from './work-search-results.component';
import { WorkQuery } from '../../interfaces/work-query';
import { WorkQueryLists } from '../../interfaces/work-query-lists';

@Component({
    selector: 'work',
    templateUrl: './work.component.html'
})
export class WorkComponent implements OnInit {
    isDateListLoaded: boolean = false;
    areWorkQueryListsLoaded: boolean = false;
    isDataLoading: boolean = false;
    isDataLoaded: boolean = false;

    results: WorkSearchResults = this.getEmptyResults();

    dates: Date[] = [];
    workQueryLists: WorkQueryLists = this.getEmptyWorkQueryLists();

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {        
    }

    ngOnInit(): void {
        this.results = this.getEmptyResults();
        this.getData('dates', (result) => {
            this.dates = result as Date[];
            this.isDateListLoaded = true;
        })
    }

    getData(resource: string, callback: (result: any) => any, date?: Date): void {
        let url = this.baseUrl + 'api/work/' + resource;
        this.http.get(url).subscribe(
            result => {
                callback(result.json());
            },
            error => {
                console.error(error);
            }
        );
    }

    onDateChanged(date: Date | null): void {
        this.areWorkQueryListsLoaded = false;
        this.isDataLoaded = false;
        this.workQueryLists = this.getEmptyWorkQueryLists();
        if (date) {
            date = new Date(date);
            let url = 'work-query-lists/' + date.toISOString().substring(0, 10) + '/' + date.getTimezoneOffset();
            this.getData(url, (result) => {
                this.workQueryLists = result as WorkQueryLists;
                this.areWorkQueryListsLoaded = true;
            })  
        }
    }

    onQuery(query: WorkQuery): void {
        this.isDataLoading = true;
        this.results = this.getEmptyResults();
        this.http.post(this.baseUrl + 'api/Work/search', query).subscribe(
            result => {
                this.results = result.json() as WorkSearchResults;
                this.isDataLoading = false;
                this.isDataLoaded = true;
            },
            error => {
                console.error(error);
                this.isDataLoading = false;
                this.isDataLoaded = true;
            }
        );
    }

    private getEmptyResults(): WorkSearchResults {
        return {
            totalCount: 0,
            pagesCount: 0,
            correctRate: 0,
            avgProgress: 0,
            workItems: []
        };
    }

    private getEmptyWorkQueryLists(): WorkQueryLists {
        return {
            subjects: [],
            domains: [],
            learningObjectives: [],
            users: [],
            exercises: [],
            correct: []
        };
    }
}
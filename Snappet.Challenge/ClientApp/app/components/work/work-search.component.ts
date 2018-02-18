import { Component, Input, Output, EventEmitter } from '@angular/core';
import { WorkQuery } from '../../interfaces/work-query';
import { WorkQueryLists } from '../../interfaces/work-query-lists';

@Component({
    selector: 'work-search',
    templateUrl: './work-search.component.html',
    styles: [`form { margin-top: 20px !important;}`]
})
export class WorkSearchComponent {
    @Input() dates: Date[];
    @Input() workQueryLists: string[];
    @Input() isLoaded: boolean;

    @Output() onQuery: EventEmitter<WorkQuery> = new EventEmitter<WorkQuery>();
    @Output() onDateChanged: EventEmitter<Date | null> = new EventEmitter<Date | null>();

    query: WorkQuery = {
        dateSubmitted: null,
        clientTimeZoneOffset: (new Date()).getTimezoneOffset(),
        subject: null,
        domain: null,
        learningObjective: null,
        correct: null,
        user: null,
        exercise: null,
        pageNumber: 0,
        itemsPerPage: 10
    };

    onDateChange(): void {
        this.onDateChanged.emit(this.query.dateSubmitted);
    }

    onSubmit(): void {
        this.onQuery.emit(this.query);
    }

    onReset(): void {
        this.onDateChanged.emit(this.query.dateSubmitted);
    }
}

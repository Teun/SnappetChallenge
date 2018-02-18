import { Component, Input } from '@angular/core';
import { WorkSearchResults } from '../../interfaces/work-search-results';

@Component({
    selector: 'work-search-results',
    templateUrl: './work-search-results.component.html',
    styles: [`ul { margin-top: 7px !important;}`]
})
export class WorkSearchResultsComponent {
    @Input() results: WorkSearchResults;
    @Input() isLoading: boolean;

    pageNumber: number = 0;
}
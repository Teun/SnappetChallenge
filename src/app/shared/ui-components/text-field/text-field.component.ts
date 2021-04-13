import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { fromEvent, Observable, of, timer } from 'rxjs';
import { catchError, debounceTime, delayWhen, distinctUntilChanged, map, retryWhen, switchMap, tap } from 'rxjs/operators';
import { Suggestion } from 'src/app/core/model/suggestion';
import { AutoSuggestionService } from 'src/app/core/services/autosuggestion/auto-suggestion.service';



@Component({
  selector: 'app-text-field',
  templateUrl: './text-field.component.html',
  styleUrls: ['./text-field.component.scss']
})
export class TextFieldComponent implements OnInit, AfterViewInit {

  @ViewChild('searchInput', { static: true }) input!: ElementRef;
  suggestions$!: Observable<Suggestion[]>;

  constructor(private suggestionService: AutoSuggestionService) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.suggestions$ = fromEvent<any>(this.input.nativeElement, 'keyup').pipe(
      map(event => event.target.value),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(search => this.loadResults(search)),
      catchError(err => of([{term: 'Error occured'}]))
    );
  }

  onSearch(): void{

  }

  loadResults(search): Observable<Suggestion[]> {
    return this.suggestionService.fetchResults(search);
  }
}

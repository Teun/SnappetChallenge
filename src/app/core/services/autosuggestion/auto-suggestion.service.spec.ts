import { TestBed } from '@angular/core/testing';

import { AutoSuggestionService } from './auto-suggestion.service';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';

describe('AutoSuggestionService', () => {
  let service: AutoSuggestionService;
  let  httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
          imports: [HttpClientTestingModule],
         providers: [AutoSuggestionService] });
    service = TestBed.get(AutoSuggestionService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it('should fetch suggestions with an Observable<Suggestion[]>', () => {
          service.fetchResults('test').subscribe(data => {
              expect(data[0].term).toEqual('John');
          });
          const request =  httpMock.expectOne('http://localhost:3000/suggestions?filter=test');
          httpMock.verify();
  });
});


import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AutoSuggestionService } from 'src/app/core/services/autosuggestion/auto-suggestion.service';

import { TextFieldComponent } from './text-field.component';

describe('TextFieldComponent', () => {
  let component: TextFieldComponent;
  let fixture: ComponentFixture<TextFieldComponent>;
  const suggestionHttpService = jasmine.createSpyObj('AutoSuggestionService', [
    'fetchResults'
  ]);
  beforeEach(async () => {
    TestBed.configureTestingModule({
        providers : [
            { provide: AutoSuggestionService, useValue: suggestionHttpService }
        ],
        schemas: [CUSTOM_ELEMENTS_SCHEMA]
    });
  });
  beforeEach(() => {
    fixture = TestBed.createComponent(TextFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

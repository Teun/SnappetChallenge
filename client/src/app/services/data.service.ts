import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocatorService } from './locator.service';
import { AppContextService, ViewEnum } from './appcontext.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(
    private http: HttpClient,
    private locator: LocatorService,
    private appContextService: AppContextService
  ) {}

  getReport() {
    const params = {
      date: this.appContextService.selection.date,
      subject: this.appContextService.selection.subject,
      domain: this.appContextService.selection.domain,
      viewtype: ViewEnum[this.appContextService.currentViewType]
    };

    return this.http.get(this.locator.config.GetReport, {
      params: params
    });
  }

  getStudentDetail() {
    const params = {
      date: this.appContextService.selection.date,
      subject: this.appContextService.selection.subject,
      domain: this.appContextService.selection.domain,
      objective: this.appContextService.selection.objective
    };

    return this.http.get(this.locator.config.GetStudentDetails, {
      params: params
    });
  }
}

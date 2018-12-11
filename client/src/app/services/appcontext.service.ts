import { Injectable, EventEmitter } from '@angular/core';

export interface Selection {
  date: string;
  domain: string;
  objective: string;
  subject: string;
}
export enum ViewEnum {
  subject,
  domain,
  learningObjective,
  student
}

@Injectable({
  providedIn: 'root'
})
export class AppContextService {
  public selection: Selection;
  public currentViewType: ViewEnum;
  public selectionChanged: EventEmitter<string> = new EventEmitter<string>();
  constructor() {
    this.selection = {
      date: '',
      domain: '',
      objective: '',
      subject: ''
    };
    this.currentViewType = ViewEnum.subject;
  }

}

import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { DataService } from '../../services/data.service';
import { AppContextService, ViewEnum } from '../../services/appcontext.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  cards: any;
  studentList: [];
  currentViewType: ViewEnum;
  title: string;
  displayNoStudentMessage: boolean;
  constructor(
    private breakpointObserver: BreakpointObserver,
    private dataService: DataService,
    private appContextService: AppContextService
  ) {
    this.currentViewType = this.appContextService.currentViewType;
    this.displayNoStudentMessage = false;
    this.setTitle();
  }

  onDateChanged(date: string) {
    this.appContextService.selection.date = date;
    this.getDataFromServer();
  }

  onchartClicked(event) {
    if (this.appContextService.currentViewType === ViewEnum.subject) {
      this.appContextService.currentViewType = ViewEnum.domain;
      this.appContextService.selection.subject = event.key;
    } else if (this.appContextService.currentViewType === ViewEnum.domain) {
      this.appContextService.currentViewType = ViewEnum.learningObjective;
      this.appContextService.selection.domain = event.key;
    } else if (
      this.appContextService.currentViewType === ViewEnum.learningObjective
    ) {
      this.appContextService.currentViewType = ViewEnum.student;
      this.appContextService.selection.objective = event.key;
    }
    this.appContextService.selectionChanged.emit('crumb');
    this.currentViewType = this.appContextService.currentViewType;
    this.getDataFromServer();
  }

  getDataFromServer() {
    if (this.appContextService.currentViewType === ViewEnum.student) {
      this.studentList = [];
      this.dataService.getStudentDetail().subscribe((result: any) => {
        this.studentList = result;
        if (this.studentList.length === 0) {
          this.displayNoStudentMessage = true;
        } else {
          this.displayNoStudentMessage = false;
        }
      });
    } else {
      this.dataService.getReport().subscribe(result => {
        this.setCards(result);
      });
    }
  }

  setCards(result) {
    this.setTitle();
    this.cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
      map(({ matches }) => {
        const cards = [];
        result.forEach(element => {
          cards.push({
            id: element.Key,
            title: element.Key,
            cols: 1,
            rows: 1,
            data: element,
            type: this.appContextService.currentViewType
          });
        });
        return cards;
      })
    );
  }

  setTitle() {
    this.title =
      this.toTitleCase(ViewEnum[this.appContextService.currentViewType]) + 's';
  }

  toTitleCase(toTransform) {
    return toTransform.replace(/\b([a-z])/g, function(_, initial) {
      return initial.toUpperCase();
    });
  }
}

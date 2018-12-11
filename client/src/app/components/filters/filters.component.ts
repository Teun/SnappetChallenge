import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AppContextService, Selection, ViewEnum } from '../../services/appcontext.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.scss']
})
export class FiltersComponent implements OnInit {
  constructor(private appContextService: AppContextService) {}
  // tslint:disable-next-line:no-output-on-prefix
  @Output()
  public onDateChanged = new EventEmitter();

  date: any;
  public crumbs = [];

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;

  ngOnInit() {
    this.prepareCrumb(this.appContextService.selection);
    this.date = new Date(
      'Tue Mar 24 2015 11:30:00 UTC'
    );
    this.date = this.convertDate(this.date) + 'T00:00:00';
    this.onDateChanged.emit(this.date);

    this.appContextService.selectionChanged.subscribe(result => {
      if (result !== 'view') {
        this.prepareCrumb(this.appContextService.selection);
      }
    });
  }

  prepareCrumb(selection: Selection) {
    this.crumbs = [];
    if (selection.subject !== '') {
      this.crumbs.push({
        name: selection.subject,
        type: ViewEnum.subject
      });
    }
    if (selection.domain !== '') {
      this.crumbs.push({
        name: selection.domain,
        type: ViewEnum.domain
      });
    }
    if (selection.objective !== '') {
      this.crumbs.push({
        name: selection.objective,
        type: ViewEnum.learningObjective
      });
    }
  }

  addEvent(event) {
    this.date = event.value.toString();
    this.date = this.convertDate(this.date) + 'T00:00:00';
    this.onDateChanged.emit(this.date);
  }

  convertDate(str: string): string {
    const date = new Date(str),
      mnth = ('0' + (date.getMonth() + 1)).slice(-2),
      day = ('0' + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join('-');
  }
}

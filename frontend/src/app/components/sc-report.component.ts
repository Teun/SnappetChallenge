import { Component } from '@angular/core';

@Component({
  selector: 'sc-report',
  template: `
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-2" style="background-color:#F2F5F7;">
          <sc-filter (Filter)="onFilter($event)"></sc-filter>
        </div>
        <div class="col-md-10">
          <sc-table [students]="students"></sc-table>
        </div>
      </div>
    </div>
  `
})
export class ReportComponent {

  students: any[];

  onFilter(event) {
    console.log(event);
    this.students = event;
  }

}

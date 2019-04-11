import { Injectable, OnInit } from '@angular/core';
import { StudentSummaryServices } from '../student-summary/student-summary.service';
import * as _ from 'underscore';
import { tap, map } from 'rxjs/operators';

@Injectable()
export class StudentReportServices {

  constructor(private studentSummaryServices: StudentSummaryServices) {
  }

  getTop10() {
    return this.studentSummaryServices.getSummary().pipe(
      map(data => _.chain(data).sortBy(item => item.correct).first(10).value())
    );
  }

  getBottom10() {
    return this.studentSummaryServices.getSummary().pipe(
      map(data => _.chain(data).sortBy(item => item.correct).reverse().last(10).value())
    );
  }
}

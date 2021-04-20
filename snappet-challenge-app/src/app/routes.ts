import {Route} from "@angular/router";

export const OVERVIEW_ROUTE: Route = {
  path: 'overview',
  data: { title: 'Class Overview' },
}

export const STUDENT_ROUTE: Route = {
  path: 'students',
  data: { title: 'Students' },
}

export const rootRoutesMap = [OVERVIEW_ROUTE, STUDENT_ROUTE];

import {Route} from "@angular/router";

export const OVERVIEW_ROUTE: Route = {
  path: 'overview',
  data: { title: 'Class Overview' },
}

export const STUDENT_ROUTE: Route = {
  path: 'student',
  data: { title: 'Student' },
}

export const EXERCISE_ROUTE: Route = {
  path: 'exercise',
  data: { title: 'Exercise' },
}

export const rootRoutesMap = [OVERVIEW_ROUTE, STUDENT_ROUTE, EXERCISE_ROUTE];

import { Excercise } from './excercise';

export interface SubjectGroup {
  subject: string;
  objectives: Array<{
    objective: string;
    excercises: Array<Excercise>;
    answers: number;
  }>;
}

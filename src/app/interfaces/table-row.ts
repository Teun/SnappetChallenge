import {LearningObjective, UserId} from "../models/answer";

export interface TableAnswer {
  correct: 0 | 1;
  learningObjective: LearningObjective;
}

export interface TableRow {
  userId: UserId;
  userName: string;
  answers: TableAnswer[];
}

export type UserId = number;
export type LearningObjective = string;

export const allLearningObjectives = "allLearningObjectives";

export interface Answer {
  Correct: 0 | 1;
  Difficulty: string;
  Domain: string;
  ExerciseId: number
  LearningObjective: LearningObjective;
  Progress: number;
  Subject: string;
  SubmitDateTime: string;
  SubmittedAnswerId: number;
  UserId: UserId;
}

export const SubmitDate = (data: Answer) => data.SubmitDateTime.split('T')[0];

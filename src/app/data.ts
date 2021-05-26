export type UserId = number;

export interface Data {
  Correct: 0 | 1;
  Difficulty: string;
  Domain: string;
  ExerciseId: number
  LearningObjective: string;
  Progress: number;
  Subject: string;
  SubmitDateTime: string;
  SubmittedAnswerId: number;
  UserId: UserId;
}

export const SubmitDate = (data: Data) => data.SubmitDateTime.split('T')[0];

export interface ElementInterface {
  SubmittedAnswerId: number;
  SubmitDateTime: Date;
  Correct: 1 | 0;
  Progress: 1 | 0;
  UserId: number;
  ExerciseId: number;
  Difficulty: string;
  Subject: string;
  Domain: string;
  LearningObjective: string;
}

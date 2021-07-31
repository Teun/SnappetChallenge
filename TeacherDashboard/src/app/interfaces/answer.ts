export interface Answer {
  SubmittedAnswerId: number;
  SubmitDateTime: Date;
  Correct: boolean;
  Progress: number;
  UserId: number;
  ExerciseId: number;
  Difficulty: string;
  Subject: string;
  Domain: string;
  LearningObjective: string;

}

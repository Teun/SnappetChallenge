export interface ApiAnswer {
  SubmittedAnswerId: number,
  SubmitDateTime: string,
  Correct: 1 | 0,
  Progress: number,
  UserId: number,
  ExerciseId: number,
  Difficulty: string,
  Subject: string,
  Domain: string,
  LearningObjective: string,
}

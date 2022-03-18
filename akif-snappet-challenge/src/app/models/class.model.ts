export interface RawData {
  SubmittedAnswerId: number;
  SubmitDateTime: string;
  Correct: number;
  Progress: number;
  UserId: number;
  ExerciseId: number;
  Difficulty: string;
  Subject: string;
  Domain: string;
  LearningObjective: string;
}

export interface Domains {
  Getallen: Subject[];
  Meten: Subject[];
  Taalverzorging: Subject[];
  Verbanden: Subject[];
  Verhoudingen: Subject[];
  others: Subject[];
}

export interface Subject {
  name: string;
  items: Array<{
    ExerciseId: number;
    UserId: number;
    SubmitDateTime: string;
    Difficulty: string;
    Progress: number;
    Correct: 0 | 1;
  }>;
}

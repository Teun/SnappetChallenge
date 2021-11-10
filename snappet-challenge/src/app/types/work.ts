export interface Work {
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

export interface LearningObjectivesDetails {
  [objectiveName: string]: {
    count: number;
  };
}
export interface DomainDetails {
  [domainName: string]: {
    count: number;
    objectives: LearningObjectivesDetails;
  };
}
export interface SubjectDetails {
  count: number;
  domains: DomainDetails;
}
export interface ProcessedWorkData {
  [subjectName: string]: SubjectDetails;
}

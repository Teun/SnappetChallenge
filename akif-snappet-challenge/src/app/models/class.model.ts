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

export enum DomainNames {
  Getallen = 'Getallen',
  Meten = 'Meten',
  Taalverzorging = 'Taalverzorging',
  Verbanden = 'Verbanden',
  Verhoudingen = 'Verhoudingen',
  noDomain = 'noDomain',
}
export enum SubjectNames {
  BegrijpendLezen = 'Begrijpend Lezen',
  Spelling = 'Spelling',
  Rekenen = 'Rekenen',
}
export interface Domains {
  [DomainNames.Getallen]: Domain[];
  [DomainNames.Meten]: Domain[];
  [DomainNames.Taalverzorging]: Domain[];
  [DomainNames.Verbanden]: Domain[];
  [DomainNames.Verhoudingen]: Domain[];
  [DomainNames.noDomain]: Domain[];
}
export interface Subjects {
  [SubjectNames.Spelling]: Domain[];
  [SubjectNames.Rekenen]: Domain[];
  [SubjectNames.BegrijpendLezen]: Domain[];
}

export interface Domain {
  name: string;
  items: Array<DomainItem>;
}

export interface DomainItem {
  ExerciseId: number;
  UserId: number;
  SubmitDateTime: string;
  Difficulty: string;
  Subject: string;
  Progress: number;
  Correct: 0 | 1;
}

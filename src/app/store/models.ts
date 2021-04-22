export interface Work {
  SubmittedAnswerId: number,
  SubmitDateTime: string,
  Correct: 0 | 1 | 3,
  Progress: number,
  UserId: number,
  ExerciseId: number,
  Difficulty: string,
  Subject: string,
  Domain: string,
  LearningObjective: string
}

export type FilterState = { [key: string]: (string | number) }

export type FilterKeys = keyof Work ;

export interface Store {
  isLoading: boolean;
  filterValues: { [key: string]: (string | number)[] };
  filterState: FilterState;
  works: Work[];
  chartData: {name: string, value: number}[];
}

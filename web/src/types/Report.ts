export interface ReportResponse{
  subjectReport: NamedBinaryReport[]
  domainReport: NamedBinaryReport[]
  learningObjectiveReport: NamedBinaryReport[]
  difficultyRangeReport: NamedBinaryReport[]
}

export interface NamedBinaryReport{
  name: string
  trueCount: number
  falseCount: number
}
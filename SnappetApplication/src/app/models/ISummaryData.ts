export interface ISummaryData {
  id: number;
  name: string;
  attempted: number;
  correct: number;
  incorrect: number;
}

export interface IStudentV1Dto {
  studentId: number;
  name: string;
}

export interface IResultV1Dto {
  submittedAnswerId: number;
  submitDateTime: string;
  correct: number;
  progress: number;
  userId: number;
  exerciseId: number;
  subject: string;
}

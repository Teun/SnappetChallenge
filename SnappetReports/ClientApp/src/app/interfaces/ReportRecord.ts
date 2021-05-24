interface ReportRecord
{
  subject: string;
  difficulty: string;  
  domain: string;
  correct: number;
  userid: number;
  learningObjective: string;
  exerciseId: number;
  submitDateTime: Date;
  submittedAnswerId: number;
  progress: number;
}

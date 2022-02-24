export interface DetailedReportProps {
  reportData: Array<DataStructure>;
}

export interface DataStructure {
  amountCorrects: number;
  learningObjective: string;
  percentageCorrect: number;
  subject: string;
}
 export interface JsonStructure {
   SubmittedAnswerId: number;
   SubmitDateTime: string;
   Correct: 1 | 0;
   Progress: number;
   UserId: number;
   ExerciseId: number;
   Difficulty: string;
   Subject: string;
   Domain: string;
   LearningObjective: string;
 }

 export interface SubjectValue {
  [subject: string]: number;
 }

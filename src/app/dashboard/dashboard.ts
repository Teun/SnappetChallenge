export interface WorkReport {
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

export interface CardData {
    submittedEntries: number;
    correctEntries: number;
    successRate: number;
    studentNumber: number;
}

export interface Student {
    subjectSplit: any;
    subjectProgress: any;
    subjectSuccessRate: any;
}

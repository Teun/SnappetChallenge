export interface StudentResults {
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

export interface StudentAverage {
    UserId: number;
    Average: number;
}

export interface SubjectAverage {
    Subject: string;
    Average: number;
}
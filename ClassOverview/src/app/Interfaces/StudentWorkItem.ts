export interface StudentWorkItem {
    submittedAnswerId: number;
    submitDateTime: Date;
    correct: boolean;
    progress: number;
    userId: number;
    exerciseId: number;
    difficulty: string;
    subject: string;
    domain: string;
    learningObjective: string;
}
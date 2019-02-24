export interface LearningData {
    id: number,
    submittedAnswerId: number,
    submitDateTime: Date,
    correct: number,
    progress: number,
    userId: number,
    exerciseId: number,
    difficulty: string,
    subject: string,
    domain: string,
    learningObjective: string
}

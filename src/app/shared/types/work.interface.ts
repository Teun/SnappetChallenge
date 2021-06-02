export interface Work {
    submittedAnswerId: number
    submitDateTime: Date,
    correct: number,
    progress: number,
    userId: number,
    exerciseId: number,
    difficulty: number,
    subject: string,
    domain: string,
    learningObjective: string
}

export interface WorkItem {
    submittedAnswerId: Number;
    submitDateTime: Date;
    correct: Boolean;
    progress: Number;
    userId: Number;
    exerciseId: Number;
    difficulty: String;
    subject: String;
    domain: String;
    learningObjective: String;
}
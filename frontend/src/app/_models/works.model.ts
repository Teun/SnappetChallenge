export default interface Work {
    SubmittedAnswerId?: number;
    SubmitDateTime?: string;
    Correct?: number;
    Progress?: number;
    UserId?: number;
    ExerciseId?: number;
    Difficulty?: string;
    Subject?: string;
    Domain?: string;
    LearningObjective?: string;

    startdate?: string;
    enddate?: string;
    ActivityCount?: number;
}

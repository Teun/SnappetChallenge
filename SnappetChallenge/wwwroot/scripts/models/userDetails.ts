module SnappetChallenge.Models {
    export class UserDetails {
        userId: number;
        name: string;
        imageId: number;
        averageProgress: number;
        learningObjectives: LearningObjectiveForUserDetails[];
    }

    export class LearningObjectiveForUserDetails {
        name: string;
        domain: string;
        subject: string;
        overallProgress: number;
        answers: SubmittedAnswer[];
    }

    export class SubmittedAnswer {
        answerId: number;
        exerciseId: number;
        difficulty: string;
        correct: boolean;
        submitDateTime: Date;
        progress: number;
    }
}
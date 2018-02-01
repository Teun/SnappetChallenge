module SnappetChallenge.Models {
    export class LearningObjective {
        name: string;
        domain: string;
        subject: string;
        averageProgress: number;
        users: UserForLearningObjective[];
    }

    export class UserForLearningObjective {
        userId: number;
        name: string;
        overallProgress: number;
        imageId: number;
    }
}
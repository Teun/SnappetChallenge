module SnappetChallenge.Models {
    export class LearningObjective {
        public name: string;
        public domain: string;
        public subject: string;
        public averageProgress: number;
        public users: UserForLearningObjective[];
    }
}
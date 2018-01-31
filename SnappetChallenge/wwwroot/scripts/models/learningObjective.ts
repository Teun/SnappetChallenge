module SnappetChallenge.Models {
    export class LearningObjective {
        public Name: string;
        public Domain: string;
        public Subject: string;
        public AverageProgress: number;
        public Users: UserForLearningObjective[];
    }
}
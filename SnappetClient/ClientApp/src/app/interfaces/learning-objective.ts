import { LearningData } from './learning-data';
export interface LearningObjective {
    name: string,
    numberOfExercises: number,
    numberOfPupils: number,
    averageProgress: number,
    learningData: LearningData[]
}

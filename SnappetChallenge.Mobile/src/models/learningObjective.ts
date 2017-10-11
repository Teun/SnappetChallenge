import { Exercise } from './exercise';

export class LearningObjective {
    Subject: string;
    Domain: string;
    Objective: string;
    NumberOfQuestions: string
    Exercises: Exercise[];
    FirstQuestionAnswered: string;
}
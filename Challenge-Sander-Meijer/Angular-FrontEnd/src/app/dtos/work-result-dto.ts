export class WorkResultDto {

    correct: boolean;
    excerciseId: number;
    domain: string;
    learningObjective: string;

    constructor(data: {
        correct: boolean,
        excerciseId: number,
        domain: string,
        learningObjective: string
    }) {
        this.correct = data.correct;
        this.excerciseId = data.excerciseId;
        this.domain = data.domain;
        this.learningObjective = data.learningObjective;
    }
}
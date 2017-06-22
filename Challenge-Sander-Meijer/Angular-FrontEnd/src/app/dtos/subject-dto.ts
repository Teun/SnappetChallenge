import { WorkResultDto } from "app/dtos/work-result-dto";

export class SubjectDto {

    subject: string;
    workResults: WorkResultDto[];

    constructor(data: {

        subject: string;
        workResults: any[];
       /* {
            correct: boolean,
            excerciseId: number,
            domain: string,
            learningObjective: string
        }[]*/

    }) {
        this.subject = data.subject;
        this.workResults = data.workResults.map(item => new WorkResultDto(item))
    }
}
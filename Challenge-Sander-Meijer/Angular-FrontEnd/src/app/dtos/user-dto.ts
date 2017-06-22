import { SubjectDto } from "app/dtos/subject-dto";

export class UserDto {
    userId: number;
    subjects: SubjectDto[];

    constructor(data: {
        userId: number,
        subjects: any[]
       /* {
            subject: string;
            workResults:
            {
                correct: boolean,
                excerciseId: number,
                domain: string,
                learningObjective: string
            }[]
        }[]*/
    }) {
        this.userId = data.userId;
        this.subjects = data.subjects.map(i => new SubjectDto(i));
    }
}
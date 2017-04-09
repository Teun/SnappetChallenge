export class SubjectEditedTasksModel {
    subject: string
    count: number

    constructor(subject: string, count: number) {
        this.subject = subject;
        this.count = count;
    }
}
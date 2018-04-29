import { SubjectModel } from "./subjectModel";

export class StudentModel {
    public Id: number;
    public Name: string;
    public Subjects: Array<SubjectModel> = []; 
}  
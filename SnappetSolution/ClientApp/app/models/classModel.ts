import { SubjectModel } from "./subjectModel";
import { StudentModel } from "./StudentModel";

export class ClassModel {
    public Id: number = 0;
    public Period: string = "";
    public CurrentDate: Date;
    public PreviousResultType: string;
    public Subjects: Array<string> = [];
    public StudentsModel: Array<StudentModel> = [];
}
import { StudentModel } from "./StudentModel";

export class SubjectModel {
    public Subject: string;
    public Users: StudentModel[]=[];
}
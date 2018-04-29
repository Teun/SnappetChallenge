import { StatisticsModel } from "./StatisticsModel";
import { SubjectModel } from "./subjectModel";

export class ClassModel {
    public Id: number = 0;
    public Period: string = "";
    public CurrentDate: Date;
    public PreviousResultType: string;
    public TotalProgress: StatisticsModel;
    public ResultsPerSubjects: SubjectModel[] = [];
}
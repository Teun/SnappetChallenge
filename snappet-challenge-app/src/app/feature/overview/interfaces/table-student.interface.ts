import {ApiStudent} from "@core/interfaces/api-student.interface";

export interface TableStudent extends ApiStudent{
  progress: number;
  correctAnswers: number;
}

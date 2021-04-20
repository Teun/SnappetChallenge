import {ApiStudent} from "@shared/interfaces/api-student.interface";

export interface TableStudent extends ApiStudent{
  progress: number;
  correctAnswers: number;
}

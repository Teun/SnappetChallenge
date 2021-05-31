import { ReportResponse } from "../types/Report";

export const getReportForStudent = (studentId: number, date: Date | undefined) : Promise<ReportResponse> =>
fetch(`http://localhost/SubmittedAnswers/GetReportForStudent?studentId=${studentId}${date?"&date="+date.toISOString():""}`)
  .then(res => res.json())
  .catch(rej => console.log(rej));

export const getReportForClass = (date: Date | undefined) : Promise<ReportResponse> =>
fetch(`http://localhost/SubmittedAnswers/GetReportForClass${date?"?date="+date.toISOString():""}`)
  .then(res => res.json())
  .catch(rej => console.log(rej));
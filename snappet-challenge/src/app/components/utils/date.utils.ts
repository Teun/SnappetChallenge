import {ResultsModel} from "../../models/results.model";

export function getResults(results: Array<ResultsModel>, startDateTime: Date, endDateTime: Date): Array<ResultsModel> {
  return results.filter(result => (new Date(result.SubmitDateTime) >= startDateTime && (new Date(result.SubmitDateTime) < endDateTime)));
}

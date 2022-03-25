import { RawData, Subjects } from '../models/class.model';

export function sortByDate(items: RawData[]): RawData[] {
  return items.sort((a, b) => {
    return new Date(a.SubmitDateTime).getTime() - new Date(b.SubmitDateTime).getTime();
  });
}

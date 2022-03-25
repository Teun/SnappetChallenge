import { Domain, DomainItem, Domains, RawData, SubjectNames, Subjects } from '../models/class.model';

export function domainsFromService(items: RawData[]): Subjects {
  const returnValue = {
    [SubjectNames.BegrijpendLezen]: [],
    [SubjectNames.Rekenen]: [],
    [SubjectNames.Spelling]: [],
  };
  items.forEach((item) => {
    const isSubjectAlreadyExist = returnValue[item.Subject].some((i) => i.name === item.Domain);
    const domainItem = {
      ExerciseId: item.ExerciseId,
      UserId: item.UserId,
      SubmitDateTime: item.SubmitDateTime,
      Difficulty: item.Difficulty,
      Progress: item.Progress,
      Correct: item.Correct,
      Domain: item.Domain,
      Subject: item.Subject,
    };

    if (!isSubjectAlreadyExist) {
      returnValue[item.Subject].push({
        name: item.Domain,
        items: [domainItem],
      });
    } else {
      returnValue[item.Subject].map((i) => {
        if (i.name === item.Domain) {
          i.items = [...i.items, domainItem];
        }
      });
    }
  });
  return returnValue;
}

export function getProgressData(domain: Domain): number[] {
  let acc = 0;
  return domain.items.map((item: DomainItem) => {
    acc = acc + item.Progress;
    return acc;
  });
}

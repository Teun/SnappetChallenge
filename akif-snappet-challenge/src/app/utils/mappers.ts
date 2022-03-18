import { Domains, RawData } from '../models/class.model';

export function domainsFromService(items: RawData[]):Domains {
  const returnValue = {
    Getallen: [],
    Meten: [],
    Taalverzorging: [],
    Verbanden: [],
    Verhoudingen: [],
    others: [],
  };
  items.forEach((item) => {
    const isSubjectAlreadyExist = returnValue[item.Domain].some(
      (i) => i.name === item.Subject
    );
    const subjectItem = {
      ExerciseId: item.ExerciseId,
      UserId: item.UserId,
      SubmitDateTime: item.SubmitDateTime,
      Difficulty: item.Difficulty,
      Progress: item.Progress,
      Correct: item.Correct,
      Domain:item.Domain
    };

    if (!isSubjectAlreadyExist) {
      returnValue[item.Domain].push({
        name: item.Subject,
        items: [subjectItem],
      });
    } else {
      returnValue[item.Domain].map((i) => {
        if (i.name === item.Subject) {
          i.items = [...i.items, subjectItem];
        }
      });
    }
  });
  return returnValue;
}

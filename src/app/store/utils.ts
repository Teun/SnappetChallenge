import {FilterKeys, FilterState, Work} from "./models";

export const getUniqueValues = (data: Work[], key: FilterKeys) => {
  return data.map(item => item[key]).filter((val, index, array) => array.indexOf(val) === index)
}
export const initFilter = (works: Work[]) => {
  const filterKeys: FilterKeys[] = ['UserId', 'Subject', 'Domain', 'LearningObjective'];
  return filterKeys.reduce((acc, key) => {
    const filterData = getUniqueValues(works, key);
    return {...acc, [key]: getTypeGuardByKey(key)(filterData) ? filterData : []};
  }, {})
}


export const getChartData = (data: Work[]) => {
  const progressByLearningObjective = data.reduce((acc, item) => {
    if (Object.keys(acc).includes(item.LearningObjective)) {
      const value = acc[item.LearningObjective] += item.Progress;
      return {...acc, ...value}
    }
    return {...acc, [item.LearningObjective]: item.Progress };
  }, {});
  return Object.keys(progressByLearningObjective).map(key => {
    const value = progressByLearningObjective[key];
    return { name: key + ' Progress: ' + value, value: Math.abs(value)};
  })
}

export const getChartDataByFilter = (works: Work[], filter: Partial<FilterState>) => {
  const filterKeys = Object.keys(filter).filter(key => filter[key] !== null);
  if (!filterKeys.length) {
    return getChartData(works);
  }
  const data = works.filter(item => filterKeys.every(key => item[key] === filter[key]) );
  return getChartData(data);
}

export const getTypeGuardByKey = (key: string) => key === 'UserId' ? isNumbers : isStrings;
export const isNumbers = (arr: (string | number)[]): arr is number[] => typeof arr[0] === "number";
export const isStrings = (arr: (string | number)[]): arr is string[] => typeof arr[0] === "string";

import {JsonStructure, DataStructure, SubjectValue} from './Types';

const now = new Date(Date.UTC(2015, 3, 24, 11, 30, 0)); // '2015-03-24 11:30:00 UTC'

const transformDataForDetailedReport = (studentResults: Array<JsonStructure>): Array<DataStructure> => {
  return studentResults.reduce((processedResult, studentResult) => {
    if (new Date(studentResult.SubmitDateTime) < now) {

    }
    return processedResult;
  }, [] as Array<DataStructure>);
};

const transformDataForChartReport = (studentResults: Array<JsonStructure>): Array<Array<string | number>> => {
  const filteredResults = studentResults.filter(
    (studentResult) => new Date(studentResult.SubmitDateTime) < now
  );
  const uniqueSubjects = getAllSubjects(filteredResults);
  const amountCorrectsBySubject = getAmountCorrectsBySubject(filteredResults);
  const averageDifficultyBySubject = getAverageDifficultyBySubject(filteredResults);

  const processedReport: Array<Array<string | number>> = [
    ['Subject', 'Amount Corrects', 'Average Difficulty']
  ];
  uniqueSubjects.forEach((subject) => {
    processedReport.push(
      [subject, amountCorrectsBySubject[subject], averageDifficultyBySubject[subject]]
    );
  });

  return processedReport;
};

const getAllSubjects = (studentResults: Array<JsonStructure>): Set<string> => {
  return new Set<string>(
    studentResults.map((studentResult) => studentResult.Subject)
  );
};

const getTotalQuestionsBySubject = (studentResults: Array<JsonStructure>): SubjectValue => {
  return studentResults.reduce((totalQuestionsBySubject, {Subject}) => {
    Object.assign(totalQuestionsBySubject, {
      [Subject]: totalQuestionsBySubject[Subject] !== undefined
        ? totalQuestionsBySubject[Subject] + 1
        : 0
    });
    return totalQuestionsBySubject;
  }, {} as SubjectValue);
};

const getTotalDifficultyBySubject = (studentResults: Array<JsonStructure>): SubjectValue => {
  return studentResults.reduce((totalDifficultyBySubject, {
    Subject,
    Difficulty
  }) => {
    const difficulty = Number(Difficulty);
    const valueDifficulty = Number.isNaN(difficulty) ? 0 : difficulty;
    Object.assign(totalDifficultyBySubject, {
      [Subject]: totalDifficultyBySubject[Subject]
        ? totalDifficultyBySubject[Subject] + valueDifficulty
        : valueDifficulty
    });
    return totalDifficultyBySubject;
  }, {} as SubjectValue);
};

const getAmountCorrectsBySubject = (studentResults: Array<JsonStructure>): SubjectValue => {
  return studentResults.reduce((correctsBySubject, {Subject, Correct}) => {
    Object.assign(correctsBySubject, {
      [Subject]: correctsBySubject[Subject] ? correctsBySubject[Subject] + Correct : Correct
    });
    return correctsBySubject;
  }, {} as SubjectValue);
};

const getAverageDifficultyBySubject = (studentResults: Array<JsonStructure>): SubjectValue => {
  const totalDifficultyBySubject: SubjectValue = getTotalDifficultyBySubject(studentResults);
  const totalQuestionsBySubject: SubjectValue = getTotalQuestionsBySubject(studentResults);
  const averageDifficultyBySubject: SubjectValue = {};

  Object.entries(totalDifficultyBySubject).forEach(([subject, totalDifficulty]) => {
    Object.assign(averageDifficultyBySubject, {
      [subject]: (totalDifficulty / totalQuestionsBySubject[subject])
    })
  });

  return averageDifficultyBySubject;
};

export {transformDataForDetailedReport, transformDataForChartReport};


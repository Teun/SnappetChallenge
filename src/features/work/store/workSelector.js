import { createSelector } from "reselect";
import { DateTime } from "luxon";
import { compareSameTimeStamp } from "../../../utils/dateTimeUtils";
import { groupBy, accumulateTotals } from "../../../utils/reducerUtils";
import { getWorkData } from "./workSlice";

const chosenWorkDateTime = DateTime.fromISO("20150324T073000-0400", {
  zone: "utc",
});

export const getActiveFilter = (state) => state.filter.field;

export const getSelectedDaysWork = createSelector(
  getWorkData,
  (workItems = []) =>
    workItems.filter(({ SubmitDateTime }) =>
      compareSameTimeStamp(SubmitDateTime, chosenWorkDateTime)
    )
);

export const getLearningObjectiveData = createSelector(
  getSelectedDaysWork,
  getActiveFilter,
  (workItems = [], field) => {
    const groupByFilterField = groupBy(workItems, field);
    const fieldKeys = Object.keys(groupByFilterField);
    const learnObjectiveData = fieldKeys.map((field) => ({
      field,
      data: accumulateTotals(groupByFilterField[field], "LearningObjective"),
    }));
    return learnObjectiveData;
  }
);

export const getFilteredSubjectOverview = createSelector(
  getSelectedDaysWork,
  getActiveFilter,
  (dailyWork = [], field) => {
    return accumulateTotals(dailyWork, field);
  }
);

export const getPerformanceReportData = createSelector(
  getSelectedDaysWork,
  getActiveFilter,
  (workItems = [], field) => {
    const groupByFilterField = groupBy(workItems, field);
    const fieldKeys = Object.keys(groupByFilterField);
    const performanceReportData = fieldKeys.map((field) => ({
      field,
      data: accumulateTotals(groupByFilterField[field], "Correct"),
    }));
    return performanceReportData;
  }
);

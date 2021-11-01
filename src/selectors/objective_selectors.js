import { createSelector } from "reselect"
import { DateTime } from "luxon"
import _ from "lodash"

const getWorkData = (state) => state.workData.data
export const getActiveFilter = (state) => state.workData.activeSubject

const today = new Date(`2015-03-24 11:30:00 UTC`).toISOString()

const calculateTotals = (array = [], field) => {
  return array.reduce((acc, o) => ((acc[o[field]] = (acc[o[field]] || 0) + 1), acc), {})
}

const compareSameTimeStamp = (date1, date2, compareString = "day") => {
  const d1 = DateTime.fromISO(date1, { zone: "utc" })
  const d2 = DateTime.fromISO(date2, { zone: "utc" })
  return d1.hasSame(d2, compareString)
}

export const getTodaysWork = createSelector(getWorkData, (workItems = []) =>
  workItems.filter(({ SubmitDateTime }) => compareSameTimeStamp(SubmitDateTime, today))
)

export const getLearningObjectiveData = createSelector(getTodaysWork, getActiveFilter, (workItems = [], field) => {
  const groupByFilterField = _.groupBy(workItems, field)
  const fieldKeys = Object.keys(groupByFilterField)
  const learnObjectiveData = fieldKeys.map((field) => ({ field, data: calculateTotals(groupByFilterField[field], "LearningObjective") }))
  return learnObjectiveData
})

export const getFilteredDailyOverview = createSelector(getTodaysWork, getActiveFilter, (dailyWork = [], field) => {
  return calculateTotals(dailyWork, field)
})

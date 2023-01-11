import { DateTime } from "luxon";

export const compareSameTimeStamp = (date1, date2, compareString = "day") => {
  const d1 = DateTime.fromISO(date1, { zone: "utc" });
  const d2 = DateTime.fromISO(date2, { zone: "utc" });
  return d1.hasSame(d2, compareString);
};

export const convertLocalToUTCDate = (date) => {
  if (!date) {
    return date;
  }
  date = new Date(date);
  date = new Date(
    Date.UTC(date.getFullYear(), date.getMonth(), date.getDate())
  );
  return date;
};

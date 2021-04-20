export const dayInMs = 86400000;
export const addDaysToDate = (date: Date, days: number) => new Date(date.getTime() + days * dayInMs);
export const subtractDaysFromDate = (date: Date, days: number) => new Date(date.getTime() - days * dayInMs);

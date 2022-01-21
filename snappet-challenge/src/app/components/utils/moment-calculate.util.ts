import * as moment from "moment";
import DurationConstructor = moment.unitOfTime.DurationConstructor;

export function MomentCalculateUtil(today: Date, now: Date, timeBefore: DurationConstructor): {compareDateStart: Date, compareDateEnd: Date }{
  const compareDateStart: any = new Date(moment(today).subtract(1, timeBefore).format());
  const compareDateEnd: any = new Date(moment(now).subtract(1, timeBefore).format());
  return {compareDateStart: compareDateStart, compareDateEnd: compareDateEnd};
}

export function calculateMinusDays(timeBefore: string): DurationConstructor {
  let minusDays: DurationConstructor = 'day';
  if(timeBefore === 'yesterday') {
    minusDays = 'day';
  } else if(timeBefore === 'previous-week'){
    minusDays = 'week';
  }
  else if(timeBefore === 'previous-month') {
    minusDays = 'month';
  }
  return minusDays;
}

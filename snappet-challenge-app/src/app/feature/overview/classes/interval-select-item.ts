import {subtractDaysFromDate} from "@shared/helpers/date-time.helper";

export class IntervalSelectItem {
  from: Date;

  constructor(public text: string, public value: string, public to: Date, subtractDays?: number) {
    if (subtractDays){
      this.from = subtractDaysFromDate(this.to, subtractDays);
    } else {
      this.from = this.to;
    }
  }
}

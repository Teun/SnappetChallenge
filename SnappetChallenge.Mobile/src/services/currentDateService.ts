import { Injectable } from '@angular/core';

@Injectable()
export class CurrentDateService {

    private date: Date;
    private days: string[] = ["zo", "ma", "di", "wo", "do", "vr", "za"]

    constructor() {
        this.date = new Date(Date.UTC(2015, 2, 24)); // new Date();
    }

    getCurrentDate(): string {
        return this.days[this.date.getDay()] + " " + this.date.toLocaleDateString();
    }

    addDays(change: number): void {
        this.date = new Date(this.date.getFullYear(), this.date.getMonth(), this.date.getDate() + change);
    }

    getFromDate(): string {
        return this.date.toISOString();
    }

    // This code is required temporarily to make sure we don't get data after '24-03-2015 11:30'
    getToDate(): string {
        const dateLimit = new Date(2015, 2, 24, 11, 30);
        var toDate = new Date(this.date.getFullYear(), this.date.getMonth(), this.date.getDate() + 1);
        return toDate > dateLimit ? dateLimit.toISOString() : toDate.toISOString();
    }
}
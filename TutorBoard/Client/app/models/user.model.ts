import * as ko from "knockout";

export class UserProgressModel {
    userId: KnockoutObservable<number>
    name: KnockoutObservable<string>
    progress: KnockoutObservable<number>
    progressClass: KnockoutComputed<string>

    constructor(userId: number, name: string, progress: number) {
        this.userId = ko.observable(userId);
        this.name = ko.observable(name);
        this.progress = ko.observable(progress);
        this.progressClass = ko.computed({
            owner: this,
            read: () => {
                if (this.progress() == 0) return "progress-none";
                if (this.progress() < 0) return "progress-negative";
                return "progress-positive";
            }
        });
    }
}
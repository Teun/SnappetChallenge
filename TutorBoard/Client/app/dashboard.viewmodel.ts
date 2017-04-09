import * as ko from "knockout";
import * as $ from "jquery";

import { SubjectEditedTasksModel } from "./models/subject-edited-tasks.model";
import { UserProgressModel } from "./models/user.model";

export class DashboardViewModel {
    editedTasksCount: KnockoutObservable<number>
    editedTasksPerSubject: KnockoutObservableArray<SubjectEditedTasksModel>
    userProgresses: KnockoutObservableArray<UserProgressModel>
    
    constructor() {
        this.editedTasksCount = ko.observable(0);
        this.editedTasksPerSubject = ko.observableArray([]);
        this.userProgresses = ko.observableArray([]);
        this.load();
    }

    load() {
        $.getJSON('/api/dailyreport', (data) => {
            this.editedTasksCount(data.EditedTasks.Summary);
            this.editedTasksPerSubject($.map(data.EditedTasks.SubjectCounts, (entry) => new SubjectEditedTasksModel(entry.Subject, entry.Count)));
            this.userProgresses($.map(data.UserProgress, (entry) => new UserProgressModel(entry.UserId, entry.UserName, entry.Progress)).sort((l: UserProgressModel, r: UserProgressModel) => {
                return l.name().localeCompare(r.name());
            }));
        });
    }
}
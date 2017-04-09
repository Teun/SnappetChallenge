import * as ko from "knockout";
import * as $ from "jquery";
import * as app from "./dashboard.viewmodel";

$(() => {
    // Activate Knockout
    ko.applyBindings(new app.DashboardViewModel());
});
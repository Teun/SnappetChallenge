define('binder', ['jquery', 'ko', 'vm'], function ($, ko, vm) {

    /* This bind function is doing too many things and violating CQS,
     * but for now I does update bindings *after*
     * getting the data */
    var bind = function () {
        $.getJSON('api/class-insights', function (data) {
            vm.classInsights.requestedDate = data.RequestedDate;
            vm.classInsights.amountOfAnswers = data.AmountOfAnswers;
            vm.classInsights.amountOfAnswersCorrect = data.AmountOfAnswersCorrect;
            vm.classInsights.totalProgress = data.TotalProgress;
            vm.classInsights.mostProgress = data.MostProgress;
            vm.classInsights.mostDifficultyWith = data.MostDifficultyWith;
            vm.classInsights.topObjectivesStudied = data.TopObjectivesStudied;

            ko.applyBindings(vm.classInsights);
        });
    }

    return {
        bind: bind
    };
});

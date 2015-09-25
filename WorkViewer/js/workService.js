(function () {
    var workService = function () {
        var getAnswers = function () {
            return self.q(function (onSuccess) {
                $.getJSON("api/work", function (anwers) {
                    application.cache.add('work', anwers);
                    onSuccess(anwers);
                });
            });
        },
        matchFilter = function (filter, dataItem) {
            var isMatch = !(filter.endDate) || dataItem.SubmitDateTime < filter.endDate;
            isMatch &= (filter.selectedDomain || '') === '' || dataItem.Domain === filter.selectedDomain;
            isMatch &= (filter.selectedObjective || '') === '' || dataItem.LearningObjective === filter.selectedObjective;
            return isMatch;
        },
        addAnserToProgressArray = function (items, answer) {
            var item = $.grep(items, function (item) { return item.answers[0].UserId === answer.UserId })[0];
            if (!item) {
                item = { userName: 'Scholier ' + answer.UserId, progress: 0, answers: [] };
                items.push(item);
            }
            item.progress += answer.Progress;
            item.answers.push(answer);
        },
        getProgressRecords = function (filter) {
            return self.q(function (onSuccess) {
                getAnswers().then(function (anwers) {
                    var progressRecords = [];
                    $.each(anwers, function (idx, answer) {
                        if (matchFilter(filter, answer)) {
                            addAnserToProgressArray(progressRecords, answer);
                        }
                    });
                    onSuccess(progressRecords);
                });
            });
        },
        extractDomains = function (progressData) {
            var availableDomains = [];
            $.each(progressData, function (idx, progressItem) {
                $.each(progressItem.answers, function (idx, answer) {
                    if (availableDomains.indexOf(answer.Domain) == -1) {
                        availableDomains.push(answer.Domain);
                    }
                });
            });

            return availableDomains;
        },
        extractObjectives = function (progressData, selectedDomain) {
            var availableObjectives = [];
            if ((selectedDomain || '') !== '') {
                $.each(progressData, function (idx, progressItem) {
                    $.each(progressItem.answers, function (idx, answer) {
                        if (answer.Domain === selectedDomain && availableObjectives.indexOf(answer.LearningObjective) == -1) {
                            availableObjectives.push(answer.LearningObjective);
                        }
                    });
                });

                return availableObjectives;
            }
        },
        self = {
            getProgressRecords: getProgressRecords,
            extractDomains: extractDomains,
            extractObjectives: extractObjectives
        };

        return self;
    };

    application.registerService('workController', 'workService', workService);
})();
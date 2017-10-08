$(function () {
    var derivers = $.pivotUtilities.derivers;
    var renderers = $.extend($.pivotUtilities.renderers,
        $.pivotUtilities.c3_renderers);

    var _dataSource = "https://raw.githubusercontent.com/Snappet/SnappetChallenge/master/Data/work.json",
        _today = new Date(2015, 02, 24, 11, 30, 00, 00),
        _todaysAnswers;

    var _isToday = function _isToday(datettime) {
        return datettime.getUTCFullYear() === _today.getUTCFullYear()
            && datettime.getUTCMonth() === _today.getUTCMonth()
            && datettime.getUTCDate() === _today.getUTCDate();
    }

    var _getTodaysAnswers = function _getTodaysAnswers(submittedAnswers) {
        var todaysAnswers = [];
        $.each(submittedAnswers, function (index, submittedAnswer) {
            var submitDateTime = new Date(submittedAnswer.SubmitDateTime);
            if (+submitDateTime <= +_today && _isToday(submitDateTime)) {
                todaysAnswers.push({
                    SubmittedAnswerId: submittedAnswer.SubmittedAnswerId,
                    SubmitDateTime: submitDateTime,
                    Correct: submittedAnswer.Correct,
                    Progress: submittedAnswer.Progress,
                    UserId: submittedAnswer.UserId,
                    ExerciseId: submittedAnswer.ExerciseId,
                    Difficulty: +submittedAnswer.Difficulty,
                    Subject: submittedAnswer.Subject,
                    Domain: submittedAnswer.Domain,
                    LearningObjective: submittedAnswer.LearningObjective
                });
            }
        });
        return todaysAnswers;
    }

    var _showReport = function _showReport(reportName) {
        $('#pivottable').empty();
        if (reportName === 'waaraan') {
            _showWaaraanReport();
        } else if (reportName === 'hoe') {
            _showHoeReport(false);
        } else if (reportName === 'hoedetail') {
            _showHoeReport(true);
        }
        return true;
    }

    var _showWaaraanReport = function _showWaaraanReport() {
        $('#pivottable').pivotUI(_todaysAnswers, {
            renderers: renderers,
            rendererName: "Table Barchart",
            aggregatorName: "Count",
            cols: ["UserId"],
            rows: ["Subject", "LearningObjective"],
            rowOrder: "key_a_to_z",
            colOrder: "key_a_to_z"
        }, true);
        // hide rendererName and unused fields
        $('#pivottable').find('tr').find('td:eq(0)').hide();
        // show totals
        $('#pivottable').removeClass('hideTotals');
    }

    var _showHoeReport = function _showHoeReport(detail) {
        var _progressAggregator = function (data, rowKey, colKey) {
            return {
                count: 0,
                values: [],
                text: '',
                push: function (record) {
                    this.count++;
                    this.values.push(record.Progress);
                },
                value: function () {
                    // TODO: how to aggregate progress?
                    return (this.count > 0) ? this.values.join(', ') : 'error';
                },
                format: function (value) {
                    return value;
                },
                numInputs: 0
            }
        };
        $.extend($.pivotUtilities.aggregators,
            {
                "TODO: Progress Aggregator": function () {
                    return _progressAggregator;
                }
            });
        $('#pivottable').pivotUI(_todaysAnswers, {
            renderers: renderers,
            rendererName: "Table",
            aggregatorName: (detail) ? "TODO: Progress Aggregator" : "List Unique Values",
            cols: ["UserId"],
            rows: ["Subject", "LearningObjective"],
            vals: ["Progress"],
            rowOrder: "key_a_to_z",
            colOrder: "key_a_to_z"
        }, true);
        // hide rendererName, unused fields and totals
        $('#pivottable').find('tr').find('td:eq(0)').hide();
        $('#pivottable').addClass('hideTotals');
    }

    $.getJSON(_dataSource, function (submittedAnswers) {
        _todaysAnswers = _getTodaysAnswers(submittedAnswers);
        $('#reports').on('change', function () {
            _showReport(this.value);
        })
    });
});
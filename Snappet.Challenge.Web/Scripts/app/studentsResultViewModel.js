define(["knockout", "highcharts", "customBindingHandlers/autocomplete", "customBindingHandlers/datepicker"], function (ko) {

    function dailyClassStatistics(dailyStatObj) {
        this.x = dailyStatObj.x;
        this.y = dailyStatObj.y;
        this.avgDifficulty = dailyStatObj.avgDifficulty;
        this.amountOfProgressedStudents = dailyStatObj.amountOfProgressedStudents;
        this.correct = dailyStatObj.correct;
        this.incorrect = dailyStatObj.incorrect;
    }

    function learningObjectiveStatistics(learningObjectve, dailyStatistics) {
        this.learningObjectve = learningObjectve;
        this.dailyStatistics = dailyStatistics || [];
    };

    return function () {
        var self = this;

        self.fromDate = ko.observable();
        self.toDate = ko.observable();
        self.selectedSubjectDomain = ko.observable();
        self.statistics = ko.observableArray([]);

        self.updateStatis = ko.computed(function () {
            if (self.selectedSubjectDomain() && self.fromDate()
                && self.toDate() && self.fromDate() <= self.toDate()) {

                $.getJSON("/Home/GetClassLearningObjectiveStatChartData",
                    {
                        subject: self.selectedSubjectDomain().subject,
                        domain: self.selectedSubjectDomain().domain,
                        from: self.fromDate().toISOString(),
                        to: self.toDate().toISOString()
                    },
                    function (data) {
                        self.statistics($.map(JSON.parse(data), function (loStat) {
                            var dailyStatistics = $.map(loStat.dailyStatistics, function (dailyStat) {
                                return new dailyClassStatistics(dailyStat);
                            });
                            return new learningObjectiveStatistics(loStat.learningObjective, dailyStatistics);
                        }));
                    });
            }
        }).extend({ rateLimit: 10 });

        // autocomplete functionality
        self.findSubjectDomain = function(request, response) {
            var query = request.term;

            $.getJSON("/Home/SearchForSubectDomains",
                { query: query },
                function(data) {
                    response($.map(JSON.parse(data), function(sd) {
                        return {
                            value: { subject: sd.subject, domain: sd.domain },
                            label: sd.subject + (sd.domain ? " / " + sd.domain : "")
                        };
                    }));
                });
        };

        self.selectSubjectDomain = function (event, ui) {
            self.selectedSubjectDomain(ui.item.value);
            return false;
        };

        // chart
        var chart = new window.Highcharts.Chart({
            chart: {
                renderTo: 'chart',
                type: 'spline',
                zoomType: 'x'
            },
            title: {
                text: 'Average Class Progress'
            },
            yAxis: {
                title: {
                    text: 'Average Class Progress change'
                }
            },
            xAxis: {
                type: 'datetime',
                dateTimeLabelFormats: {
                    month: '%e of %b'
                },
                title: {
                    text: 'Date'
                }
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle',
                borderWidth: 0
            },
            tooltip: {
                formatter: function () {
                    return "Average difficulty: <b>" + (this.point.avgDifficulty ? Math.round(this.point.avgDifficulty) : "unavalable") + " </b><br />" +
                        "Progressed students: <b>" + this.point.amountOfProgressedStudents + " </b><br />" +
                        "Correct / incorrect answers: <b>" + this.point.correct + " / " + this.point.incorrect + "</b>";
                }
            }
        });

        self.statistics.subscribe(function (stat) {
            while (chart.series.length > 0)
                chart.series[0].remove(false);

            for (var i = 0, l = stat.length; i < l; i++) {
                chart.addSeries({
                    name: stat[i].learningObjectve,
                    id: stat[i].learningObjectve,
                    data: stat[i].dailyStatistics,
                    visible: i < 5
                }, false);
            }

            chart.redraw();
        });
    }
});
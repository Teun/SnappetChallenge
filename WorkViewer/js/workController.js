(function () {
    var workController = function () {
        var init = function () {
            self.services.workService.getProgressRecords(
                { endDate: endDate }
            )
            .then(function (progressRecords) {
                initViewModel();
                viewModel().allProgressRecords(progressRecords).progressChartHeight(calcChartHeight(progressRecords.length)).progressRecords(progressRecords);
                $('#overlay').hide();
                $('#contentContainer').show();
                ko.applyBindings(viewModel, $('#contentContainer')[0]);
            });
        },
        update = function()
        {
            var model = viewModel();
            self.services.workService.getProgressRecords(
                { endDate: endDate, selectedDomain: model.selectedDomain(), selectedObjective: model.selectedObjective() }
            )
            .then(function (progressRecords) {
                viewModel().progressChartHeight(calcChartHeight(progressRecords.length)).progressRecords(progressRecords);
            });
        },
        endDate = '2015-03-20T07:54:33.693',
        heightPerRecord = 32,
        headerHeight = 120,
        footerHeight = 60,
        calcChartHeight = function(numberOfRecords) {
            return headerHeight + heightPerRecord * numberOfRecords + footerHeight;
        },
        viewModel = ko.observable(),
        initViewModel = function () {
            viewModel({
                allProgressRecords: ko.observableArray(),
                progressRecords: ko.observableArray(),
                availableDomains: undefined,
                selectedDomain: ko.observable(),
                hasSelectedDomain : undefined,
                availableObjectives: undefined,
                selectedObjective: ko.observable(),
                progressChartHeight: ko.observable()
            });
            setComputedFunctions(viewModel());
            setSubscriptions(viewModel());
        },
        setComputedFunctions = function (model) {
            model.hasSelectedDomain = ko.computed(function () {
                return (model.selectedDomain() || '') !== '';
            });
            model.availableDomains = ko.computed(function () {
                return self.services.workService.extractDomains(model.allProgressRecords());
            });
            model.availableObjectives = ko.computed(function () {
                return self.services.workService.extractObjectives(model.allProgressRecords(), model.selectedDomain());
            });
        },
        setSubscriptions = function (model) {
            model.selectedDomain.subscribe(function (newDomainValue) {
                update();
            });
            model.selectedObjective.subscribe(function (newObjectiveValue) {
                update();
            });
        },
        createChart = function () {
            $("#container").dxChart({
                rotated: true,
                dataSource: progressRecords,
                commonSeriesSettings: {
                    argumentField: "userName",
                    type: "bar",
                    hoverMode: "allArgumentPoints",
                    selectionMode: "allArgumentPoints",
                    label: {
                        visible: true,
                        format: "number"
                    }
                },
                valueAxis: {
                    label: {
                        format: "number"
                    }
                },
                series: [
                    { valueField: "progress", name: "Progress" },
                ],
                title: {
                    text: "Voortgang scholieren"
                },
                legend: {
                    verticalAlignment: "bottom",
                    horizontalAlignment: "center"
                },
                onPointClick: function (e) {
                    e.target.select();
                },
                onLegendClick: function (e) {
                    var series = e.target;
                    series.isVisible() ? series.hide() : series.show();
                }
            });
        },
        self = {
            init: init
        };

        return self;
    };

    application.registerController('workController', workController);
})();
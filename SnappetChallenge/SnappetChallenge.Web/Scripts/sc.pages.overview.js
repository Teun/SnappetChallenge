"use strict";

var sc = sc || {};
sc.pages = sc.pages || {};
sc.pages.overview = function () {

    var defaultStartDate,
        defaultEndDate,
        defaultStartTime,
        defaultEndTime,
        currPage = 0,
        pageSize = 100,
        koBindingApplied = false,
        viewModel,
        scrollSelector;

    var viewModelOverview = function () {
        var self = this;

        self.items = ko.observableArray([]).extend({ rateLimit: 100 }).distinct("Domain"); // wait to notify subscribers in case we're adding multiple items, also create grouping index
        self.dateStartForEditting = ko.observable(defaultStartDate);
        self.dateEndForEditting = ko.observable(defaultEndDate);
        self.timeStartForEditting = ko.observable(defaultStartTime);
        self.timeEndForEditting = ko.observable(defaultEndTime);
        self.groupingEnabled = ko.observable(true);

        self.applyFilter = function () {
            self.items.removeAll();
            currPage = 0;
            retrieveItems();
        }

        self.resetFilter = function () {
            self.dateStartForEditting(defaultStartDate);
            self.dateEndForEditting(defaultEndDate);
            self.timeStartForEditting(defaultStartTime);
            self.timeEndForEditting(defaultEndTime);
            self.applyFilter();
        }


        self.dateStart = ko.computed(function () {
            return sc.utils.getIsoDateTimeString(self.dateStartForEditting(), self.timeStartForEditting());
        });
        self.dateEnd = ko.computed(function () {
            return sc.utils.getIsoDateTimeString(self.dateEndForEditting(), self.timeEndForEditting());
        });

        self.allDomains = ko.computed(function () {
            var domains = ko.utils.arrayMap(self.items(), function (item) {
                return item.Domain();
            });
            return domains.sort();
        }, self);

        self.uniqueDomains = ko.computed(function () {
            return ko.utils.arrayGetDistinctValues(self.allDomains()).sort();
        }, self);

        self.groupingEnabledForEditting = ko.computed({
            read: function () {
                return self.groupingEnabled().toString();
            },
            write: function (newVal) {
                self.groupingEnabled(newVal === "true");
            },
            owner: self
        });
    }

    var initialize = function (options) {
        /* set initial variables passed from view */
        defaultStartDate = options.defaultStartDate;
        defaultEndDate = options.defaultEndDate;
        defaultStartTime = options.defaultStartTime;
        defaultEndTime = options.defaultEndTime;
        pageSize = options.pageSize;
        scrollSelector = options.scrollSelector;

        /* create viewmodel */
        viewModel = new viewModelOverview();

        /* register infinite scroll */
        registerEvents();

        /* get data from API */
        retrieveItems();
    }

    var registerEvents = function() {
        $(document).scroll(function (e) {
            if (sc.utils.isScrollable(scrollSelector)) {
                currPage++;
                retrieveItems();
            }
        });
    }

    var retrieveItems = function () {
        $.ajax({
            url: "/api/studentanswer/retrieve",
            data: { offset: currPage * pageSize, pageSize: pageSize, start: viewModel.dateStart(), end: viewModel.dateEnd() },
            cache: false,
            dataType: 'json',
            method: 'GET',
            success: retrieveItemsSuccess
        });
    };

    var retrieveItemsSuccess = function (data) {
        $.each(data.items, function (index, value) {
            var partialModel = ko.mapping.fromJS(value);

            // parse the JSON date to something we can read
            partialModel.parsedDate = ko.computed(function () {
                return moment(partialModel.SubmitDateTime()).format("DD-MM-YYYY hh:mm");
            });
            viewModel.items.push(partialModel);
        });
        if (!koBindingApplied) {
            ko.applyBindings(viewModel);
            koBindingApplied = true;
        }
    };

    return {
        initialize: initialize
    }
}();